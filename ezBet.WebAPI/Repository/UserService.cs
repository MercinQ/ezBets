using ezBet.WebAPI.Domain;
using ezBet.WebAPI.Model;
using ezBet.WebAPI.Model.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace ezBet.WebAPI.Repository
{
    public class UserService : IUserService
    {
        private readonly IConfiguration _configuration;
        private readonly EzBetDbContext _ezBetDbContext;

        public UserService(EzBetDbContext ezBetDbContext, IConfiguration configuration)
        {
            _configuration = configuration;
            _ezBetDbContext = ezBetDbContext;
        }

        public string GetToken(string login, string password)
        {
            var user = _ezBetDbContext.Users.Where(x => x.Login == login).FirstOrDefault();

            if (user == null)
            {
                return null;
            }

            if (user.Password != ComputeHash(password + user.Salt))
            {
                return "Wrong password";
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var secret = _configuration["Secret"];
            var key = Encoding.ASCII.GetBytes(_configuration["AppSettings:Secret"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString())
                }),
                Expires = DateTime.Now.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public bool Register(UserModelDTO user)
        {
            if (!_ezBetDbContext.Users.Any(x => x.Login == user.Login))
            {
                var userDb = new User();
                userDb.Login = user.Login;
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
            byte[] inputBytes = Encoding.UTF8.GetBytes(input);
            byte[] hashedBytes = new SHA512CryptoServiceProvider().ComputeHash(inputBytes);
            var hash = BitConverter.ToString(hashedBytes);

            return hash;
        }
    }


    public interface IUserService
    {
        string GetToken(string login, string password);
        bool Register(UserModelDTO user);
    }
        
}
