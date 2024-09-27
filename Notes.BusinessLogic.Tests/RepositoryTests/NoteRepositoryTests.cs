using Moq;
using NoteApp.DataAccess.Data.Models;
using NoteApp.DataAccess.Data;
using NoteApp.DataAccess.Repositories.NoteApp.DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq.EntityFrameworkCore;

namespace Notes.BusinessLogic.Tests.RepositoryTests
{
    public class NoteRepositoryTests
    {
        [Fact]
        public void Should_Succesfully_AddNote()
        {
            List<Note> notes = new List<Note>
            {
                new Note(),
                new Note()
            };

            Note noteTest = new Note();

            var mock = new Mock<TestContext>();
            mock.Setup(x => x.Notes).ReturnsDbSet(notes);
            mock.Setup(x => x.Notes.Add(noteTest))
                .Callback(() => notes.Add(noteTest));

            var noteRepo = new NoteRepository(mock.Object);

            noteRepo.AddNote(noteTest);

            mock.Verify(mock => mock.Notes.Add(noteTest), Times.Once);
            Assert.Equal(3, notes.Count);
        }
    }
}

