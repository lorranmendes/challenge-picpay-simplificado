namespace PicPaySimplificado.Infrastructure.Mapping
{
    public class WalletMap : IEntityTypeConfiguration<Wallet>
    {
        public void Configure(EntityTypeBuilder<Wallet> builder)
        {
            builder.ToTable("Wallets");

            builder.HasKey(x => x.Id);
            
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.IdUser);
            builder.Property(x => x.Balance).HasColumnType("decimal(18,2)");

            builder.HasOne(x => x.User)
                .WithOne(x => x.Wallet)
                .HasForeignKey<Wallet>(x => x.IdUser);
        }
    }
}
