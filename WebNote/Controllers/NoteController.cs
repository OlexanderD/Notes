using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NoteApp.BusinessLogic.Inrerfaces;
using NoteApp.DataAccess.Data.Models;
using WebNote.Common.Mappings;
using WebNote.ViewModels;

namespace WebNote.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NoteController : ControllerBase
    {
        
            private readonly INoteService _noteService;

           private readonly IMapper _mapper;

            public NoteController(INoteService noteService,IMapper mapper)
            {
                _noteService = noteService;
                _mapper = mapper;
            }


        [HttpGet]
            public List<Note> GetAllNotes(int userId)
            {
                return _noteService.GetAllNotes(userId);
            }

        [HttpPost]
            public void AddNote(NoteViewModels noteViewModel)
            {            
                _noteService.AddNote(_mapper.Map<Note>(noteViewModel));
            }

            [HttpDelete("{id}")] 
            public void RemoveNote(int id)
            {
                _noteService.DeleteNote(id);
            }

        [HttpGet("{id}")]
            public Note GetNote(int id)
            {
                return _noteService.GetNoteById(id);
            }
        [HttpPut]
            public void UpdateNote(NoteViewModels noteViewModel)
            {
                 
                _noteService.UpdateNote(_mapper.Map<Note>(noteViewModel));
            }
        }
    }

