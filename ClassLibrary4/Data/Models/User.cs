using Microsoft.AspNetCore.Identity;
using NoteApp.DataAccess.Data.Models;

namespace NoteApp.Data.Data.Models
{
    public class User : IdentityUser
    {
        public List<Note> Notes { get; set;}
    }
}
