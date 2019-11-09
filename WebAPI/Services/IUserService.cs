using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Controllers;

namespace WebAPI.Services
{
    public interface IUserService
    {
        string GetToken(string login, string password);
        bool Register(UserModel user);
    }
}
