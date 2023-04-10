using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace sisfo_campus.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly AccountRepository repository;
        private readonly IConfiguration configuration;

        public AccountsController(AccountRepository repository, IConfiguration configuration)
        {
            this.repository = repository;
            this.configuration = configuration;
        }

        [HttpPost("Register")]
        public async Task<ActionResult> Register(RegisterVM registerVM)
        {
            try
            {
                var result = await repository.Register(registerVM);
                return result is 0
                    ? Conflict(new { statusCode = 409, message = "Data fail to Insert!" })
                    : Ok(new { statusCode = 200, message = "Data Saved Succesfully!" });
            }
            catch
            {
                return BadRequest(new { statusCode = 400, message = "Something Wrong!" });
            }
        }

        [HttpPost]
        [Route("Login")]
        public async Task<ActionResult> Login(LoginVM loginVM)
        {
            try
            {
                var result = await repository.Login(loginVM);
                if (result == false)
                {
                    return Conflict(new
                    {
                        StatusCode = 409,
                        Message = "Account or Password Does not Match!"
                    });
                }
                var userdata = repository.GetUserdata(loginVM.Email);
                var roles = repository.GetRolesByNik(loginVM.Email);

                var claims = new List<Claim>()
                {
                    new Claim(ClaimTypes.Email, userdata.Email),
                    new Claim(ClaimTypes.Name, userdata.FullName)
                };

                foreach (var item in roles)
                {
                    claims.Add(new Claim(ClaimTypes.Role, item));
                }

                /*return result is false
                   ? Conflict(new { statusCode = 409, message = "Account or Password Does not Match!" })
                   : Ok(new { statusCode = 200, message = "Login Success!" });*/
                if (userdata == null)
                {
                    return Conflict(new
                    {
                        StatusCode = 409,
                        Message = "Account or Password Does not Match!"
                    });
                }
                else
                {

                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Key"]));
                    var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                    var token = new JwtSecurityToken(
                        issuer: configuration["JWT:Issuer"],
                        audience: configuration["JWT:Audience"],
                        claims: claims,
                        expires: DateTime.Now.AddMinutes(10),
                        signingCredentials: signIn
                        );

                    var generateToken = new JwtSecurityTokenHandler().WriteToken(token);
                    return Ok(new
                    {
                        StatusCode = 200,
                        Message = "Login Success!",
                        Data = generateToken
                    });
                }
            }
            catch
            {
                return BadRequest(new
                {
                    StatusCode = 400,
                    Message = "Something Wrong ",
                });
            }

        }
    }
}
