namespace PicPaySimplificado.Infrastructure.Mapping
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Name).HasMaxLength(100);
            builder.Property(x => x.Email).HasConversion(email => email.Address, emailString => new Email(emailString));
            builder.Property(x => x.Password);
            builder.Property(x => x.Type).HasConversion(new EnumToNumberConverter<UserTypeEnum, int>());

            builder.HasOne(x => x.Wallet)
                .WithOne(x => x.User)
                .HasForeignKey<Wallet>(x => x.IdUser);
        }
    }
}
