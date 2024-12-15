using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using OceanaAura.Domain.Common;
using OceanaAura.Domain.Entities;
using OceanaAura.Domain.Entities.LookUp;
using OceanaAura.Persistence.Configurations;
using System.Security.Claims;

namespace OceanaAura.Persistence.AppDbContext
{
    public class OeanaAuraDbContext : DbContext
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public OeanaAuraDbContext(DbContextOptions<OeanaAuraDbContext> options, IHttpContextAccessor httpContextAccessor) : base(options)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        public DbSet<ContactUs> ContactUs { get; set; }
        //public DbSet<Order> Order { get; set; }
        //public DbSet<Invoice> Invoice { get; set; }
        public DbSet<LookUpEntity> lookups { get; set; }
        public DbSet<LookUpCategory> lookUpCategories { get; set; }
        public DbSet<Image> Images { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(typeof(OeanaAuraDbContext).Assembly);
            SeedLookUp.Seed(builder);
        }
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var entries = ChangeTracker.Entries<BaseEntity>();
            var userClaim = _httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            foreach (var entry in entries)
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Entity.CreatedOn = DateTime.Now;
                    entry.Entity.CreatedBy = userClaim;
                }
                else if (entry.State == EntityState.Modified)
                {
                    entry.Entity.ModifyOn = DateTime.Now;
                    entry.Entity.ModifyBy = userClaim;
                }
                entry.Entity.Id = 1;
            }

            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
