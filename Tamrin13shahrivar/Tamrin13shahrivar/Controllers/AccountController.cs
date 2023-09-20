using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Tamrin13shahrivar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signManager;
        public AccountController(UserManager<IdentityUser> _userManager, SignInManager<IdentityUser> _signManager)
        {
            userManager = _userManager;
            signManager = _signManager;
        }
        [HttpPost("Login")]
        public async Task<string> Login(string username, string password)
        {
            string Model = "";
            try
            {
                var checklogin = await signManager.PasswordSignInAsync(username, password, true, false);
                if (checklogin.Succeeded)
                {
                    List<Claim> claims = new List<Claim>();
                    var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("12345jjknlknknn678"));
                    var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
                    var jwtSecurityToken = new JwtSecurityToken(
                        claims: claims,
                        expires: DateTime.Now.AddMinutes(10),
                        signingCredentials: signinCredentials);
                    Model = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
                }

            }
            catch (Exception ex)
            {

            }
            return Model;



        }

        [HttpPost("Register")]
        public async Task<string> Register(string username, string password)
        {
            string Model = "";
            try
            {
                var Resualt = await userManager.CreateAsync(new IdentityUser()
                { UserName = username }
                , password);
                if (Resualt.Succeeded)
                {
                    Model = "ok";
                }
                else
                    Model = String.Join("-", Resualt.Errors);



            }

            catch (Exception ex) { }

            return Model;
        }
        [HttpPost("ResetPassword")]
        public async Task<string> Reset(string username, string password)
        {
            string Model = "";
            try
            {
                var ResetUser = await userManager.FindByNameAsync(username);
                var token = await userManager.GeneratePasswordResetTokenAsync(ResetUser);
                var result = await userManager.ResetPasswordAsync(ResetUser, token, password);
            }

            catch (Exception) { }

            return Model;
        }
    }
}
