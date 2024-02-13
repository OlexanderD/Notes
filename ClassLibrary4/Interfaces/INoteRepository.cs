using NoteApp.DataAccess.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteApp.DataAccess.Interfaces
{
    public interface INoteRepository
    {
        List<Note> GetAllNotes(string userId);

       void AddNote(Note note);

        void UpdateNote(Note note);

        void DeleteNote(int id);

        Note GetNoteById(int id);

    }
}
