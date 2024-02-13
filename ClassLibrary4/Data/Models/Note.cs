using Microsoft.AspNetCore.Identity;
using NoteApp.Data.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteApp.DataAccess.Data.Models
{
    public class Note
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public string UserId { get; set; }

        public User? User { get; set; }
    }
}
