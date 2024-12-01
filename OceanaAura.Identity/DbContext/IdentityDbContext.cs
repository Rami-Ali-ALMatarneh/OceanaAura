using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using OceanaAura.Identity.Models;

namespace OceanaAura.Identity.DbContext
{
    public class UserIdentityDbContext : IdentityDbContext<User>
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserIdentityDbContext(DbContextOptions<UserIdentityDbContext> options, IHttpContextAccessor httpContextAccessor)
            : base(options)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(typeof(UserIdentityDbContext).Assembly);
        }
        public override int SaveChanges()
        {
            var entries = ChangeTracker.Entries<User>();
            var userClaim = _httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            foreach (var entry in entries)
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Entity.CreatedOn = DateTime.UtcNow;
                        entry.Entity.CreatedBy = userClaim;
                }
                else if (entry.State == EntityState.Modified)
                {
                    entry.Entity.ModifyOn = DateTime.UtcNow;
                    entry.Entity.ModifyBy = userClaim;
                }
            }

            return base.SaveChanges();
        }
    }
}
