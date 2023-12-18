using NoteApp.DataAccess.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteApp.Data.Data.Models
{
    public class User
    {
        public int Id { get; set; }

        public string UserName { get; set;}

        public string Password { get; set;}

        public List<Note> notes { get; set;}
    }
}
