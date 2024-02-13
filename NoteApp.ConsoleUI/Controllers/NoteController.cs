using NoteApp.BusinessLogic.Inrerfaces;
using NoteApp.DataAccess.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteApp.ConsoleUI.Controllers
{
    public class NoteController
    {
        private readonly INoteService _noteService;

        public NoteController(INoteService noteService)
        {
            _noteService = noteService;
        }

        public List<Note> GetAllNotes(string userId)
        {
            return _noteService.GetAllNotes(userId);
        }
        public void AddNote(Note note)
        {
            _noteService.AddNote(note);
        }
        public void RemoveNote(Note note)
        {
            _noteService.DeleteNote(note);
        }
        public Note GetNote(int id)
        {
             return _noteService.GetNoteById(id);
        }
        public void UpdateNote(Note note)
        {
            _noteService.UpdateNote(note);
        }
    }
}
