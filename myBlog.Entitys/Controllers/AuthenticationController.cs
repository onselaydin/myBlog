using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using myBlog.Interfaces;
using myBlog.Models;

namespace myBlog.Entitys.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private IAuthentication _iAuthentication;
        private Microsoft.Extensions.Configuration.IConfiguration _configuration;
        private IAccount accRepo;
        public AuthenticationController(IAccount _account, IAuthentication authentication, Microsoft.Extensions.Configuration.IConfiguration configuration)
        {
            this.accRepo = _account;
            _iAuthentication = authentication;
            _configuration = configuration;
        }

        [HttpPost]
        [Route("AddAccount")]
        public async Task<IActionResult> AddAccount([FromBody]Account model)
        {
            if (await _iAuthentication.UserExists(model.Nick))
            {
                ModelState.AddModelError("UserName", "Username already exists");
            }
            if (ModelState.IsValid)
            {
                try
                {
                    //var accId = await accRepo.AddAccount(model);
                    var accId = await _iAuthentication.Register(model, model.PasswordSalt);
                    if (accId != null)
                    {
                        return Ok(accId);
                    }
                    else
                    {
                        return NotFound(accId);
                    }
                }
                catch (System.Exception)
                {
                    return BadRequest();
                }
            }
            return BadRequest();
        }
        [HttpPost("login")]
        public async Task<ActionResult> Login([FromBody] Account account)
        {
            var user = await _iAuthentication.Login(account.Nick, account.PasswordSalt);
            if (user == null)
            {
                return Unauthorized();
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration.GetSection("AppSettings:Token").Value);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier, user.User_Id.ToString()),
                    new Claim(ClaimTypes.Name, user.Nick)
                }),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key)
                , SecurityAlgorithms.HmacSha512Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);
            return Ok(tokenString);
        }
    }
}