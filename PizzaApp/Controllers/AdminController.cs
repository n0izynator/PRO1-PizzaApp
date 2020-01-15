using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using PizzaApp.Models;

namespace PizzaApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        /*     private readonly IConfiguration _configuration;
             private readonly s16682Context _context;

             public AdminController(s16682Context context, IConfiguration configuration)
             {
                 _context = context;
                 _configuration = configuration;
             }

             [HttpPost("login")]
             public IActionResult Login(Admin request)
             {
                 //TODO Here we should check the credentials! Here we are just taking the first user.
                 var user = _context.Admin.ToList().First();

                 if (user == null) return NotFound();

                 var userclaim = new[] {
                         new Claim(ClaimTypes.Name, user.Login),
                         new Claim(ClaimTypes.Role, "user"),
                         new Claim(ClaimTypes.Role, "admin")
                         //Add additional data here
                     };

                 var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["SecretKey"]));
                 var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                 var token = new JwtSecurityToken(
                     issuer: "https://localhost:5001",
                     audience: "https://localhost:5001",
                     claims: userclaim,
                     expires: DateTime.Now.AddMinutes(1),
                     signingCredentials: creds
                 );

                 user.RefreshToken = Guid.NewGuid().ToString();
                 user.RefreshTokenExpirationDate = DateTime.Now.AddDays(1);
                 _context.SaveChanges();

                 return Ok(new
                 {
                     token = new JwtSecurityTokenHandler().WriteToken(token),
                     refreshToken = user.RefreshToken
                 });
             }

             [HttpPost("{refreshToken}/refresh")]
             public IActionResult RefreshToken([FromRoute]string refreshToken)
             {
                 var user = _context.Admin.SingleOrDefault(m => m.RefreshToken == refreshToken);
                 if (user == null)
                 {
                     return NotFound("Refresh token not found");
                 }

                 //TODO Here we should additionally check if the refresh token hasn't expired!

                 var userclaim = new[] {
                         new Claim(ClaimTypes.Name, user.UserName),
                         new Claim(ClaimTypes.Role, "user"),
                         new Claim(ClaimTypes.Role, "admin")
                         //Add additional data here
                     };

                 var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["SecretKey"]));
                 var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                 var token = new JwtSecurityToken(
                     issuer: "https://localhost:5001",
                     audience: "https://localhost:5001",
                     claims: userclaim,
                     expires: DateTime.Now.AddMinutes(1),
                     signingCredentials: creds
                 );

                 user.RefreshToken = Guid.NewGuid().ToString();
                 user.RefreshTokenExpirationDate = DateTime.Now.AddDays(1);
                 _context.SaveChanges();

                 return Ok(new
                 {
                     token = new JwtSecurityTokenHandler().WriteToken(token),
                     refreshToken = user.RefreshToken
                 });
             } */
    }
}