using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using GlobalFinance.Server.Data;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GlobalFinance.Server.Controllers
{
    [Route("[Controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly AppDataContext appDataContext;

        public AuthController(IConfiguration configuration, AppDataContext appDataContext)
        {
            _configuration = configuration;
            this.appDataContext = appDataContext;
        }

        [HttpPost("register")]
        public async Task<ActionResult<User>> Register(UserDto request)
        {
            string passwordHash = BCrypt.Net.BCrypt.HashPassword(request.Password);
            User? existingAccount = await appDataContext.Users.FirstOrDefaultAsync(U => U.Email == request.Email);
            bool hasExistingAccount = existingAccount == null ? false : true;

            if (!hasExistingAccount)
            {
                User user = new User { Email = request.Email, PasswordHash = passwordHash, CustomerId = request.CustomerId };
                appDataContext.Add(user);
                appDataContext.SaveChanges();

                return Ok(user);
            } else
            {
                return BadRequest("USER-ALREADY-EXISTS");
            }
        }

        [HttpPost("login")]
        public async Task<ActionResult<string>> Login(UserDto request)

        {
            User? account = await appDataContext.Users.FirstOrDefaultAsync(U => U.Email == request.Email);

            if (account == null)
            {
                return BadRequest("INVALID-CREDENTIALS");

            } else if (!BCrypt.Net.BCrypt.Verify(request.Password, account.PasswordHash))
            {
                return BadRequest("INVALID-CREDENTIALS");

            } else
            {
                string token = CreateToken(request);
                return Ok(token);
            }
        }

        private string CreateToken(UserDto user)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Email)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(s: _configuration.GetSection("AppSettings:Token")!.Value ?? ""));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                    claims: claims,
                    expires: DateTime.Now.AddDays(1),
                    signingCredentials: creds
                );

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }
    }
}

