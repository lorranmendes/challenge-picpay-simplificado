namespace PicPaySimplificado.Application.Services
{
    public class UserService : IUserService
    {
        private const decimal InitialBalance = 100.00m;
        private readonly IUnitOfWork unitOfWork;
        public UserService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<Response<int>> AddAsync(User user)
        {            
            await ValidateAlreadyUsedFieldsAsync(user);
            user.Wallet ??= new Wallet(user.Id, InitialBalance);
            user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);
            await unitOfWork.UserRepository.AddAsync(user);
            await unitOfWork.SaveChangesAsync();
            return new Response<int>(user.Id);
        }

        private async Task ValidateAlreadyUsedFieldsAsync(User user)
        {
            var existingUser = await unitOfWork.UserRepository
                .FindAsync(x => x.Document == user.Document || 
                                x.Email == user.Email);

            if (existingUser is null)
                return;

            if (user.Email.Address == existingUser.Email.Address)
                throw new AlreadyUsedException(string.Format(DefaultMessages.AlreadyUsed, "Email"));

            if (user.Document == existingUser.Document)
                throw new AlreadyUsedException(string.Format(DefaultMessages.AlreadyUsed, "CPF/CNPJ"));
        }
    }
}
