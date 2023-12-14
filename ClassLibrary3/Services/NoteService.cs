using Microsoft.EntityFrameworkCore;
using NoteApp.BusinessLogic.Inrerfaces;
using NoteApp.DataAccess.Data.Models;
using NoteApp.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static NoteApp.BusinessLogic.Services.NoteService;

namespace NoteApp.BusinessLogic.Services
{
    public class NoteService:INoteService
    {
        
            private readonly INoteRepository _noteRepository;

            public NoteService(INoteRepository noteRepository)
            {
                _noteRepository = noteRepository;
            }

            public List<Note> GetAllNotes()
            {
                return _noteRepository.GetAllNotes();
            }
            public void AddNote(Note note)
        {
             _noteRepository.AddNote(note);
        }
        public void UpdateNote(Note note)
        {
            _noteRepository.UpdateNote(note);
        }
        public void DeleteNote(Note note)
        {
            _noteRepository.DeleteNote(note);
        }
        public Note GetNoteById(int id)
        {
            return _noteRepository.GetNoteById(id);
        }
    }
    
}
