using CleanArchitecture.Core.Domain.Account;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using TimeZoneConverter;

namespace CleanArchitecture.Infra.Data.Identity
{
    public class AuthenticateService : IAuthenticate
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly IConfiguration configuration;

        public AuthenticateService(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IConfiguration configuration)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.configuration = configuration;
        }

        public async Task<bool> Authenticate(string email, string password)
        {
            var result = await signInManager.PasswordSignInAsync(
                email,
                password,
                false,
                lockoutOnFailure: false
            );

            var claims = new[]
            {
                new Claim(ClaimTypes.Email, email),
                new Claim(ClaimTypes.Name, email)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("This is the key that we will use in encryption"));
            
            var token = new JwtSecurityToken(
                issuer: "https://localhost:44321/",
                audience: "https://localhost:44321/",
                claims: claims,
                expires: TimeZoneInfo.ConvertTime(DateTime.Now.AddSeconds(30), TZConvert.GetTimeZoneInfo("America/Sao_Paulo")),
                signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256)
            );

            string tokenAsString = new JwtSecurityTokenHandler().WriteToken(token);

            return result.Succeeded;
        }

        public async Task<bool> RegisterUser(string email, string password)
        {
            var applicationUser = new ApplicationUser() { UserName = email, Email = email };

            var result = await userManager.CreateAsync(applicationUser, password);

            if(result.Succeeded)
            {
                await signInManager.SignInAsync(applicationUser, isPersistent: false);
            }

            return result.Succeeded;
        }

        public async Task Logout()
        {
            await signInManager.SignOutAsync();
        }
    }
}
