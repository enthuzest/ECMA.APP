using Microsoft.EntityFrameworkCore;

namespace ECMA.APP.Models
{
    public partial class EcmaContext : DbContext
    {
        public EcmaContext()
        {
        }

        public EcmaContext(DbContextOptions<EcmaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TblContract> TblContracts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TblContract>(entity =>
            {
                entity.HasKey(e => new { e.ContractId, e.CreatedDate });

                entity.Property(e => e.ContractId).IsUnicode(false);

                entity.Property(e => e.Owner).IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
