using BackEndv2.Data;
using BackEndv2.Helper;
using BackEndv2.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Mail;
using System.Security.Claims;
using System.Text;

namespace BackEndv2.Repositories
{
    public class AccountRepositories : IAccountRepositories
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> signInManager;
        private readonly IConfiguration configuration;
        private readonly RoleManager<IdentityRole> roleManager;

        public AccountRepositories(UserManager<User> userManager,
            SignInManager<User> signInManager, IConfiguration confi, RoleManager<IdentityRole> roleManager) 
        {
            this._userManager = userManager;
            this.signInManager = signInManager;
            this.configuration = confi;
            this.roleManager = roleManager;
        }


        public async Task<string> SignInModelAsync(SignInModel model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);
            var passwordValid = await _userManager.CheckPasswordAsync(user, model.Password);

            if (user == null || !passwordValid)
            {
                return string.Empty;
            }

            var authClaims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, model.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var userRoles = await _userManager.GetRolesAsync(user);

            foreach (var role in userRoles)
            {
                authClaims.Add(new Claim(ClaimTypes.Role, role.ToString()));
            }

            var authenKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Secret"]));

            var token = new JwtSecurityToken(
                issuer: configuration["JWT:ValidIssuer"],
                audience: configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddMinutes(20),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authenKey, SecurityAlgorithms.HmacSha256Signature)
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public async Task<IdentityResult> SignUpModelAsync(SignUpModel model)
        {
            var user = new User
			{
				FirstName = model.FirstName,
				LastName = model.LastName,
				Email = model.Email,
				UserName = model.Email
			};

			var result = await _userManager.CreateAsync(user, model.Password);

			if (result.Succeeded)
			{
				//kiểm tra role Customer đã có
				if (!await roleManager.RoleExistsAsync(Roles.Customer))
				{
					await roleManager.CreateAsync(new IdentityRole(Roles.Customer));
				}

				await _userManager.AddToRoleAsync(user, Roles.Customer);
			}
			return result;
        }

        public async Task<bool> CheckEmailASync(string email)
        {
            try
            {
                var checkformat = new MailAddress(email); 

                var result = await _userManager.FindByEmailAsync(email);
                return result == null;
            } catch
            {
                return false;
            }
        }

        public async Task<IdentityUser> GetDetailCustomerByEmail(string id)
        {
            var result = await _userManager.FindByEmailAsync(id);
            return result;
        }

        public async Task<IdentityResult> UpdateCustomerByEmail(string email, IdentityUser updatedUser)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
            {
                return IdentityResult.Failed(new IdentityError { Description = "User not found" });
            }

            // Update user properties here
            user.UserName = updatedUser.UserName;
            user.PhoneNumber = updatedUser.PhoneNumber;
            // Other properties...

            var result = await _userManager.UpdateAsync(user);
            return result;
        }
    }
}
