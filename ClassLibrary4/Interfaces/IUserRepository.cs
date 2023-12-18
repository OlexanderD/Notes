using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using NoteApp.Data.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteApp.Data.Interfaces
{
    public interface IUserRepository
    {
        List<User> GetAllUsers();
        bool UserRegistration(User user);

        bool UserLogin(string username,string password);
    }
}
