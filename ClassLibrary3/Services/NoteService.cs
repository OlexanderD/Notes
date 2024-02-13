using NoteApp.BusinessLogic.Inrerfaces;
using NoteApp.DataAccess.Data.Models;
using NoteApp.DataAccess.Interfaces;

namespace NoteApp.BusinessLogic.Services
{
    public class NoteService:INoteService
    {

        private readonly INoteRepository _noteRepository;

        public NoteService(INoteRepository noteRepository)
        {
            _noteRepository = noteRepository;
        }

        public List<Note> GetAllNotes(string userId)
        {
            return _noteRepository.GetAllNotes(userId);
        }
        public void AddNote(Note note)
        {
             _noteRepository.AddNote(note);
        }
        public void UpdateNote(Note note)
        {
            _noteRepository.UpdateNote(note);
        }
        public void DeleteNote(int id)
        {
            _noteRepository.DeleteNote(id);
        }
        public Note GetNoteById(int id)
        {
            return _noteRepository.GetNoteById(id);
        }
    }
    
}
