using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OceanaAura.Identity.Models;

namespace OceanaAura.Identity.Configurations
{
    internal class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            var hasher = new PasswordHasher<User>();
            builder.HasData(
                 new User
                 {
                     Id = "8e445865-a24d-4543-a6c6-9443d048cdb9",
                     Email = "opscode59@gmail.com",
                     NormalizedEmail = "OPSCODE59@GMAIL.COM",
                     UserName = "admin",
                     CreatedBy = "Admin",
                     NormalizedUserName = "ADMIN",
                     PasswordHash = hasher.HashPassword(null, "Pa$$w0rd"),
                     EmailConfirmed = true}
                
            );
        }
    }
}
