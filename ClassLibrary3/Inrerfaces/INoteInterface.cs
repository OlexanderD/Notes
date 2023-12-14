using NoteApp.DataAccess.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteApp.BusinessLogic.Inrerfaces
{
   public interface INoteService
    {
        List<Note> GetAllNotes();

        void AddNote(Note note);

        void UpdateNote(Note note);

        void DeleteNote(Note note);

        Note GetId(int id);
    }
}
