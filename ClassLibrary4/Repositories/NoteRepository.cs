using Microsoft.EntityFrameworkCore;
using NoteApp.Data.Data.Models;
using NoteApp.DataAccess.Data;
using NoteApp.DataAccess.Data.Models;
using NoteApp.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteApp.DataAccess.Repositories
{
    namespace NoteApp.DataAccess.Repositories
    {
        public class NoteRepository : INoteRepository
        {
            private readonly TestContext _dbContext;

            public NoteRepository(TestContext dbContext)
            {
                _dbContext = dbContext;
            }

            public List<Note> GetAllNotes(int userId)
            {
                return _dbContext.Notes.Where(n => n.UserId == userId).ToList();
            }

            public void AddNote(Note note)
            {
                _dbContext.Notes.Add(note);
                _dbContext.SaveChanges();
            }
            public void UpdateNote(Note note)
            {
                Note existingNote = _dbContext.Notes.Find(note.Id);

                if (existingNote != null)
                {
                    existingNote.Title = note.Title;
                    existingNote.Content = note.Content;

                    _dbContext.Attach(existingNote);
                    _dbContext.SaveChanges();
                }
            }


            public void DeleteNote(Note note)
            { 
                _dbContext.Notes.Remove(note);
                _dbContext.SaveChanges();
            }
            public Note GetNoteById(int id)
            {
                return _dbContext.Notes.Find(id);
               
            }
        }
    }
}
