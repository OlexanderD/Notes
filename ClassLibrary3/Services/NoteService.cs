using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using NoteApp.BusinessLogic.Inrerfaces;
using NoteApp.Data.Data.Models;
using NoteApp.DataAccess.Data.Models;
using NoteApp.DataAccess.Interfaces;

namespace NoteApp.BusinessLogic.Services
{
    public class NoteService:INoteService
    {

        private readonly INoteRepository _noteRepository;

        private readonly IMemoryCache _memoryCache;

        private readonly ILogger<NoteService> _logger;

        public NoteService(INoteRepository noteRepository,IMemoryCache memoryCache,ILogger<NoteService> logger)
        {
            _noteRepository = noteRepository;
            _memoryCache = memoryCache;
            _logger = logger;
        }

        public List<Note> GetAllNotes(string userId)
        {
            _memoryCache.TryGetValue(userId, out List<Note> cachedNotes);
            if (cachedNotes == null)
            {
                
                cachedNotes = _noteRepository.GetAllNotes(userId);
                
                if (cachedNotes != null)
                {
                    _logger.LogInformation("Data from Database");
                    _memoryCache.Set(userId, cachedNotes, new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromMinutes(5)));
                }
            }
            else
            {
                _logger.LogInformation("Data from cache");
            }
            return cachedNotes;
        
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
