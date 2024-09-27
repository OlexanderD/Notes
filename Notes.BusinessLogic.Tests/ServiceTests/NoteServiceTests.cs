using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using Moq;
using Moq.EntityFrameworkCore;
using NoteApp.BusinessLogic.Services;
using NoteApp.Data.Data.Models;
using NoteApp.DataAccess.Data;
using NoteApp.DataAccess.Data.Models;
using NoteApp.DataAccess.Interfaces;
using NoteApp.DataAccess.Repositories.NoteApp.DataAccess.Repositories;
using System.Linq;

namespace Notes.BusinessLogic.Tests.ServiceTests
{
    public class NoteServiceTests
    {
        [Fact]
        public void Should_Successfully_GetNoteById()
        {
            Note note = new();

            var mock = new Mock<INoteRepository>();

            mock.Setup(repo => repo.GetNoteById(1)).Returns(note);

            var mockLogger = new Mock<ILogger<NoteService>>();

            var mockCache = new Mock<IMemoryCache>();

            var noteService = new NoteService(mock.Object, mockCache.Object, mockLogger.Object);

            //act
            var result = noteService.GetNoteById(1);

            Assert.Equal(note, result);
        }
        [Fact]
        public void Should_Succesfully_GetAllNotes()
        {

            string userId = "1";

            List<Note> notes = new List<Note>
            {
                new Note { UserId = userId},
                new Note { UserId = userId}
            };

            var mock = new Mock<INoteRepository>();
            mock.Setup(repo => repo.GetAllNotes(userId)).Returns(notes);

            var mockLogger = new Mock<ILogger<NoteService>>();

            var mockCache = new Mock<IMemoryCache>();
            var mockCacheEntry = new Mock<ICacheEntry>();
            mockCache.Setup(c => c.CreateEntry(userId)).Returns(mockCacheEntry.Object);

            var noteService = new NoteService(mock.Object, mockCache.Object, mockLogger.Object);

            var result = noteService.GetAllNotes(userId);

            mockCache.Verify(mock => mock.CreateEntry(userId), Times.Once);
            Assert.NotNull(result);
            Assert.Equal(notes, result);
        }
    }
}