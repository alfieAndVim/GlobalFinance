﻿using System;
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
using Microsoft.AspNetCore.Authorization;

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
        public async Task<ActionResult<UserModel>> Register(UserDto request)
        {
            string passwordHash = BCrypt.Net.BCrypt.HashPassword(request.Password);
            UserModel? existingAccount = await appDataContext.Users.FirstOrDefaultAsync(U => U.Email == request.Email);
            bool hasExistingAccount = existingAccount == null ? false : true;

            if (!hasExistingAccount)
            {
                UserModel user = new UserModel { Email = request.Email, PasswordHash = passwordHash, CustomerId = request.CustomerId, Role = "client" };
                appDataContext.Add(user);
                appDataContext.SaveChanges();

                return Ok(user);
            } else
            {
                return BadRequest("USER-ALREADY-EXISTS");
            }
        }

        [HttpPost("register_admin")]
        [Authorize(Roles = "admin")]
        public async Task<ActionResult<UserModel>> RegisterAdmin(UserDto request)
        {
            string passwordHash = BCrypt.Net.BCrypt.HashPassword(request.Password);
            UserModel? existingAccount = await appDataContext.Users.FirstOrDefaultAsync(U => U.Email == request.Email);
            bool hasExistingAccount = existingAccount == null ? false : true;

            if (!hasExistingAccount)
            {
                UserModel user = new UserModel { Email = request.Email, PasswordHash = passwordHash, CustomerId = request.CustomerId, Role = "admin" };
                appDataContext.Add(user);
                appDataContext.SaveChanges();

                return Ok(user);
            }
            else
            {
                return BadRequest("USER-ALREADY-EXISTS");
            }
        }

        [HttpPost("login")]
        public async Task<ActionResult<string>> Login(UserDto request)

        {
            UserModel? account = await appDataContext.Users.FirstOrDefaultAsync(U => U.Email == request.Email);

            if (account == null)
            {
                return BadRequest("INVALID-CREDENTIALS");

            } else if (!BCrypt.Net.BCrypt.Verify(request.Password, account.PasswordHash))
            {
                return BadRequest("INVALID-CREDENTIALS");

            } else
            {
                string token = CreateToken(request, account.Role);
                return Ok(token);
            }
        }

        [HttpGet("{email}")]
        public async Task<ActionResult<int>> GetCustomerId(string email)
        {
            UserModel? account = await appDataContext.Users.FirstOrDefaultAsync(U => U.Email == email);
            if (account == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(account.CustomerId);
            }
        }

        private string CreateToken(UserDto user, string role)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Email),
                new Claim(ClaimTypes.Role, role)
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

