using Microsoft.EntityFrameworkCore;
using PruebaTecnicaSivar.DomainCommon.Entity;
using PruebaTecnicaSivar.Infrastructure.Entity;

namespace PruebaTecnicaSivar.Infrastructure.Context
{
    public class InfrastructureEFContext : DbContext
    {
        public InfrastructureEFContext(DbContextOptions<InfrastructureEFContext> options) : base(options)
        {
        }

        public DbSet<UserEntity> Users { get; set; }
        public DbSet<RoleEntity> Roles { get; set; }
        public DbSet<CompanyEntity> Companies { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries<BaseDBEntity<Guid>>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.DateCreated = DateTime.Now;
                        entry.Entity.UserCreated = "system";
                        break;

                    case EntityState.Modified:
                        entry.Entity.DateUpdated = DateTime.Now;
                        entry.Entity.UserUpdated = "system";
                        break;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserEntity>()
                .HasOne(x => x.Role)
                .WithMany(x => x.Users)
                .HasForeignKey(x => x.RoleId)
                .IsRequired(false)
                ;

            modelBuilder.Entity<UserEntity>()
                .HasMany(x => x.Companies)
                .WithOne(x => x.User)
                .HasForeignKey(x => x.UserId)
                .IsRequired(false)
                ;

            modelBuilder.Entity<CompanyEntity>()
                .HasIndex(x => x.UserId)
                ;
        }
    }
}
