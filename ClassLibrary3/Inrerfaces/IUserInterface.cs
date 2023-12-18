using NoteApp.Data.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteApp.BusinessLogic.Inrerfaces
{
    public interface IUserService
    {
        List<User> GetAllUsers();

        bool UserRegistration(User user);

        bool UserLogin(string username,string password);
    }
}
