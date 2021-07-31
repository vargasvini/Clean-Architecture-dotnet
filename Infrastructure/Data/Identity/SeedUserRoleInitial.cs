using CleanArchitecture.Core.Domain.Account;
using Microsoft.AspNetCore.Identity;
using System;

namespace CleanArchitecture.Infra.Data.Identity
{
    public class SeedUserRoleInitial : ISeedUserRoleInitial
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public SeedUserRoleInitial(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
        }

        public void SeedUsers()
        {
            var resultUser = userManager.FindByEmailAsync("user@localhost.com").Result;
            if (resultUser == null)
            {
                var user = new ApplicationUser()
                {
                    UserName = "user@localhost.com",
                    Email = "user@localhost.com",
                    NormalizedUserName = "USER@LOCALHOST.COM",
                    NormalizedEmail = "USER@LOCALHOST.COM",
                    EmailConfirmed = true,
                    LockoutEnabled = false,
                    SecurityStamp = Guid.NewGuid().ToString()
                };

                var resultIdentity = userManager.CreateAsync(user, "Senha#2021").Result;

                if (resultIdentity.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "User").Wait();
                }
            }

            var resultAdmin = userManager.FindByEmailAsync("admin@localhost.com").Result;
            if (resultAdmin == null)
            {
                var user = new ApplicationUser()
                {
                    UserName = "admin@localhost.com",
                    Email = "admin@localhost.com",
                    NormalizedUserName = "ADMIN@LOCALHOST.COM",
                    NormalizedEmail = "ADMIN@LOCALHOST.COM",
                    EmailConfirmed = true,
                    LockoutEnabled = false,
                    SecurityStamp = Guid.NewGuid().ToString()
                };

                var resultIdentity = userManager.CreateAsync(user, "Senha#2021").Result;

                if (resultIdentity.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "Admin").Wait();
                }
            }
        }

        public void SeedRoles()
        {
            if (roleManager.RoleExistsAsync("User").Result)
            {
                var role = new IdentityRole();
                role.Name = "User";
                role.Name = "USER";
                roleManager.CreateAsync(role).Wait();
            }

            if (roleManager.RoleExistsAsync("Admin").Result)
            {
                var role = new IdentityRole();
                role.Name = "Admin";
                role.Name = "ADMIN";
                roleManager.CreateAsync(role).Wait();
            }
        }
    }
}
