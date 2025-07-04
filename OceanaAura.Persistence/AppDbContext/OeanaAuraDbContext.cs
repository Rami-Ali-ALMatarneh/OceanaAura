﻿using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using OceanaAura.Domain.Common;
using OceanaAura.Domain.Entities;
using OceanaAura.Domain.Entities.LookUp;
using OceanaAura.Domain.Entities.ProductsEntities;
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
        public DbSet<AdditionalProduct> additionalProducts { get; set; }
        public DbSet<ProductSize> productSizes { get; set; }
        public DbSet<Order> orders { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Invoice> invoices { get; set; }
        public DbSet<Feedback> feedbacks { get; set; }
        public DbSet<BottleImg>  bottleImgs { get; set; }

        public DbSet<Product> products { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(typeof(OeanaAuraDbContext).Assembly);
            SeedLookUp.Seed(builder);
            builder.Entity<Cart>().HasKey(x => x.CartId);
            builder.Entity<Cart>().HasOne(tc => tc.Order)
              .WithMany(t => t.carts)
              .HasForeignKey(tc => tc.OrderId)
              .OnDelete(DeleteBehavior.Restrict);
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
            }

            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
