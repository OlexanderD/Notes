using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using NoteApp.BusinessLogic.Inrerfaces;
using NoteApp.Data.Data.Models;
using NoteApp.DataAccess.Data.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.Json;
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
        private readonly ILogger<NoteController> _logger;
        private readonly IValidator<NoteViewModels> _validator;
        private readonly IMemoryCache _memoryCache;

        public NoteController(INoteService noteService,IMapper mapper, ILogger<NoteController> logger,IValidator<NoteViewModels> validator,IMemoryCache memoryCache)
        {
            _noteService = noteService;
            _mapper = mapper;
            _logger = logger;
            _validator = validator;
            _memoryCache = memoryCache;
        }


        [HttpGet]
        public List<Note> GetAllNotes(string userId)
        {
            _logger.LogInformation("All Notes");

            List<Note> cachedNotes = _memoryCache.Get<List<Note>>(userId);

            if (cachedNotes != null)
            {
                _logger.LogInformation("Notes retrieved from cache.");
                _memoryCache.Remove(userId);
            }
            else
            {
                _logger.LogInformation("Notes retrieved from database.");
                cachedNotes = _noteService.GetAllNotes(userId);
            }

            _memoryCache.Set(userId, cachedNotes, new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromMinutes(5)));

            return cachedNotes;
        }


        [HttpPost]
        public IActionResult AddNote(NoteViewModels noteViewModel)
        {
           
            var validationResult = _validator.Validate(noteViewModel);

            if (!validationResult.IsValid)
            {
                var errors = validationResult.Errors.Select(e => new { Property = e.PropertyName, ErrorMessage = e.ErrorMessage });
                return BadRequest(new { Errors = errors });
            }

            _noteService.AddNote(_mapper.Map<Note>(noteViewModel));

            _logger.LogInformation("New note added");

            return Ok("New note added");
        }

        [HttpDelete("{id}")] 
            public IActionResult RemoveNote(int id)
            {
                _noteService.DeleteNote(id);

               _logger.LogInformation($"Note removed {id}");

               return Ok($"Note removed {id}");
            }

        [HttpGet("{id}")]
            public Note GetNote(int id)
            { 

               _logger.LogInformation($"Note {id}");
                return _noteService.GetNoteById(id);

            }
        [HttpPut]
            public IActionResult UpdateNote(NoteViewModels noteViewModel)
            {

            var validationResult = _validator.Validate(noteViewModel);

            if (!validationResult.IsValid)
            {
                var errors = validationResult.Errors.Select(e => new { Property = e.PropertyName, ErrorMessage = e.ErrorMessage });
                return BadRequest(new { Errors = errors });
            }
            _noteService.UpdateNote(_mapper.Map<Note>(noteViewModel));

            _logger.LogInformation("Note Updated");

            return Ok("Note Updated");
            }
        }
    }

