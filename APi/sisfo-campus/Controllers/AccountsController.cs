using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using sisfo_campus.Base;
using sisfo_campus.Models;
using sisfo_campus.Repositories.Data;
using sisfo_campus.ViewModels;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace sisfo_campus.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AccountsController : BaseController<int, Account, AccountRepository>
{
    private readonly AccountRepository repository;
    private readonly IConfiguration configuration;

    public AccountsController(AccountRepository repository, IConfiguration configuration) : base(repository)
    {
        this.repository = repository;
        this.configuration = configuration;
    }

    // POST : Account/Register
    [HttpPost("Register")]
    public async Task<ActionResult> Register(RegisterVM registerVM)
    {
        try
        {
            var results = await repository.Register(registerVM);
            if (results == 0)
            {
                return BadRequest(new
                {
                    StatusCode = 400,
                    Message = "Data Gagal Disimpan"
                });
            }
            else
            {
                return Ok(new
                {
                    StatusCode = 200,
                    Message = "Data Berhasil Disimpan!"
                });
            }
        }
        catch
        {
            return BadRequest(new
            {
                StatusCode = 500,
                Message = "Something Wrong!" 
            });
        }
    }

    [HttpPost("Login")]
    public async Task<ActionResult> Login(LoginVM loginVM)
    {
        try
        {
            var results = await repository.Login(loginVM);
            if (results is false)
            {
                return Conflict(new { statusCode = 409, message = "Account Or Password Does not Match !" });
            }
            else
            {
                var userdata = await repository.GetUserData(loginVM.Email);
                var roles = await repository.GetRolesByNIK(loginVM.Email);

                var claims = new List<Claim>()
                {
                    new Claim(ClaimTypes.Email, userdata.Email),
                    new Claim(ClaimTypes.Name, userdata.FullName)
                };

                foreach (var item in roles)
                {
                    claims.Add(new Claim(ClaimTypes.Role, item));
                }

                //konfigurasi token 
                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Key"]));   //mengambil key yang ada di appsettings
                var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);                //mengkonversi key menggunakan algoritma hsha
                var token = new JwtSecurityToken(                                                       //mapping data sesuai dengan jwt security token nya 
                    issuer: configuration["JWT:Issuer"],
                    audience: configuration["JWT:Audience"],
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(10),
                    signingCredentials: signIn
                    );

                //Menggenerate pembuatan tokennya 
                var generatedToken = new JwtSecurityTokenHandler().WriteToken(token);
                return Ok(new
                {
                    StatusCode = 200,
                    Message = "Login Success!",
                    data = generatedToken
                });
            }
        }
        catch
        {
            return BadRequest(new
            {
                StatusCode = 400,
                Message = "Something Wrong!"
            });
        }


    }

}