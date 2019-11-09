using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using WebAPI.Controllers;
using WebAPI.Model;
using WebAPI.Model.Entities;

namespace WebAPI.Services
{
    public class UserService : IUserService
    {
        private readonly IConfiguration _configuration;
        private readonly EzBetDbContext _ezBetDbContext;

        public UserService(IConfiguration configuration, EzBetDbContext ezBetDbContext)
        {
            _configuration = configuration;
            _ezBetDbContext = ezBetDbContext;
        }

        public string GetToken(string login, string password)
        {
            var user = _ezBetDbContext.Users.Where(x => x.Username == login).FirstOrDefault();
            if (user == null)
                return null;

            if (user.Password != ComputeHash(password + user.Salt))
                return "Wrong password";

            var secret = _configuration.GetSection("AppSettings").GetValue<string>("Secret");

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString())
                }),
                Expires = DateTime.Now.AddHours(30),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public bool Register(UserModel user)
        {
            if (!_ezBetDbContext.Users.Any(x => x.Username == user.Login))
            {
                User userDb = new User();
                userDb.Username = user.Login;
                userDb.Salt = Guid.NewGuid().ToString();
                userDb.Password = ComputeHash(user.Password + userDb.Salt);
                _ezBetDbContext.Users.Add(userDb);
                _ezBetDbContext.SaveChanges();                
                return true;
            }
            return false;
        }

        private string ComputeHash(string input)
        {
            //https://passwordsgenerator.net/md5-hash-generator/
            byte[] hashedBytes = new MD5CryptoServiceProvider().ComputeHash(Encoding.UTF8.GetBytes(input));            
            var hash = BitConverter.ToString(hashedBytes).Replace("-","");
            return hash;
        }
    }
}
