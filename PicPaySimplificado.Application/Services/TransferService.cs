namespace PicPaySimplificado.Application.Services
{
    public class TransferService : ITransferService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly INotifier notifier;
        private readonly IAuthorizer authorizer;
        public TransferService(
            IUnitOfWork unitOfWork, 
            INotifier notifier, 
            IAuthorizer authorizer)
        {
            this.unitOfWork = unitOfWork;
            this.notifier = notifier;
            this.authorizer = authorizer;
        }

        public async Task<Response<Guid>> AddAsync(Transfer transfer)
        {
            await ValidateUsersAsync(transfer);
            MakeTransfer(transfer);

            if (!authorizer.IsAuthorized())
                throw new NotAuthorizedException(DefaultMessages.GenericError);

            using var transaction = await unitOfWork.BeginTransactionAsync();
            try
            {
                unitOfWork.UserRepository.Update(transfer.Payer);
                unitOfWork.UserRepository.Update(transfer.Payee);
                await unitOfWork.TransferRepository.AddAsync(transfer);

                var notification = notifier.Notify();
                if (!notification.Notified)
                    throw new NotifyServiceOfflineException(DefaultMessages.GenericError);

                await transaction.CommitAsync();
            }
            catch (Exception ex) 
            {
                await transaction.RollbackAsync();
                throw;
            }

            return new Response<Guid>(transfer.Id);
        }

        private void MakeTransfer(Transfer transfer)
        {
            transfer.Payer.Wallet.Withdraw(transfer.Amount);
            transfer.Payee.Wallet.Deposit(transfer.Amount);
        }

        private async Task ValidateUsersAsync(Transfer transfer)
        {
            transfer.Payer = await FindUserAsync(transfer.IdPayer);
            transfer.Payee = await FindUserAsync(transfer.IdPayee);

            if (transfer.Payer.Type == UserTypeEnum.Merchant)
                throw new MerchantUserCannotTransferException(DefaultMessages.MerchantCantBeAPayer);
        }

        private async Task<User> FindUserAsync(int idUser) =>
            await unitOfWork.UserRepository.GetByIdAsync(idUser)
                ?? throw new NotFoundException(
                    string.Format(DefaultMessages.NotFound, $"Usuário de Id {idUser}"));
    }
}
