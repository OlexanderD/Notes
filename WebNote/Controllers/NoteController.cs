using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NoteApp.BusinessLogic.Inrerfaces;
using NoteApp.DataAccess.Data.Models;

namespace WebNote.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NoteController : ControllerBase
    {
        
            private readonly INoteService _noteService;

            public NoteController(INoteService noteService)
            {
                _noteService = noteService;
            }


        [HttpGet]
            public List<Note> GetAllNotes(int userId)
            {
                return _noteService.GetAllNotes(userId);
            }

        [HttpPost]
            public void AddNote(Note note)
            {
                _noteService.AddNote(note);
            }

            [HttpDelete("{id}")] // ты в маршруте запрашиваешь id
            public void RemoveNote(Note note)
            {
                _noteService.DeleteNote(note);
            }

        [HttpGet("{id}")]
            public Note GetNote(int id)
            {
                return _noteService.GetNoteById(id);
            }
        [HttpPost("{id}")]
            public void UpdateNote(Note note)
            {
                _noteService.UpdateNote(note);
            }
        }
    }

