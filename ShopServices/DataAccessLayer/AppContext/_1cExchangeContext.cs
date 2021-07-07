using DataAccessLayer.Entities.Exchange;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace DataAccessLayer.AppContext
{
    public partial class _1cExchangeContext : DbContext
    {
        public _1cExchangeContext()
        {
        }

        public _1cExchangeContext(DbContextOptions<_1cExchangeContext> options)
            : base(options)
        {
        }

        public virtual DbSet<EmployeesDirectory> EmployeesDirectories { get; set; }
        public virtual DbSet<PrivateEntrepreneur> PrivateEntrepreneurs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=sql26;Initial Catalog=1cExchange;Persist Security Info=True;User ID=j-sql26-reader-1cExchange;Password=4ME26u5uUb74UFezefD9");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Cyrillic_General_CI_AS");

            modelBuilder.Entity<EmployeesDirectory>(entity =>
            {
                entity.HasKey(e => e.Idrref)
                    .HasName("PK__Employee__AC8ED0C4FD432353");

                entity.ToTable("EmployeesDirectory");

                entity.Property(e => e.Idrref)
                    .HasMaxLength(16)
                    .HasColumnName("_IDRRef")
                    .IsFixedLength(true);

                entity.Property(e => e.FullName).HasMaxLength(200);

                entity.Property(e => e.Inn)
                    .HasMaxLength(12)
                    .HasColumnName("INN");

                entity.Property(e => e.PersonnelNumber).HasMaxLength(200);

                entity.Property(e => e.Position).HasMaxLength(150);

                entity.Property(e => e.Subdivision).HasMaxLength(150);

                entity.Property(e => e.Version)
                    .IsRequired()
                    .HasMaxLength(8)
                    .HasColumnName("_Version")
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<PrivateEntrepreneur>(entity =>
            {
                entity.HasKey(e => e.Idrref)
                    .HasName("PK__PrivateE__AC8ED0C4474B3F15");

                entity.Property(e => e.Idrref)
                    .HasMaxLength(16)
                    .HasColumnName("_IDRRef")
                    .IsFixedLength(true);

                entity.Property(e => e.Code1C).HasMaxLength(200);

                entity.Property(e => e.CodeEgrpou)
                    .HasMaxLength(50)
                    .HasColumnName("CodeEGRPOU");

                entity.Property(e => e.FullName).HasMaxLength(200);

                entity.Property(e => e.HeadCounterparty).HasMaxLength(200);

                entity.Property(e => e.Name).HasMaxLength(150);

                entity.Property(e => e.TaxationScheme).HasMaxLength(200);

                entity.Property(e => e.Version)
                    .IsRequired()
                    .HasMaxLength(8)
                    .HasColumnName("_Version")
                    .IsFixedLength(true);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
