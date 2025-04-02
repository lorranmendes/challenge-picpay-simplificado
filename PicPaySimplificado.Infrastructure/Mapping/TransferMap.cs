namespace PicPaySimplificado.Infrastructure.Mapping
{
    public class TransferMap : IEntityTypeConfiguration<Transfer>
    {
        public void Configure(EntityTypeBuilder<Transfer> builder)
        {
            builder.ToTable("Transfers");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.IdPayer);
            builder.Property(x => x.IdPayee);
            builder.Property(x => x.Value).HasColumnType("decimal(18,2)");

            builder.HasOne(x => x.Payer)
                .WithMany()
                .HasForeignKey(x => x.IdPayer)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.Payee)
                .WithMany()
                .HasForeignKey(x => x.IdPayee)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
