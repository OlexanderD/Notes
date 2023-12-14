using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Configuration;
using NoteApp.BusinessLogic.Services;
using NoteApp.ConsoleUI.Controllers;
using NoteApp.DataAccess.Data;
using NoteApp.DataAccess.Data.Models;
using NoteApp.DataAccess.Repositories.NoteApp.DataAccess.Repositories;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = new ConfigurationBuilder();

        builder.SetBasePath(Directory.GetCurrentDirectory());

        builder.AddJsonFile("appsettings.json");

        var config = builder.Build();

        var connectionString = config.GetConnectionString("DefaultConnetion");

        // чекай фичу

        var optionsBuilder = new DbContextOptionsBuilder<TestContext>();
        var options = optionsBuilder.UseSqlite(connectionString).Options;

        using var context = new TestContext(options);

        context.Database.EnsureDeleted();
        context.Database.EnsureCreated();
        Console.WriteLine("Hello, World!");
        var noteRepository = new NoteRepository(context);
        var noteService = new NoteService(noteRepository);
        var testController = new NoteController(noteService);
        Note note1 = new Note { Title = "Help", Content = "Puka" };
        Note note2 = new Note { Title = "Pika3", Content = "FSF" };

        testController.AddNote(note1);
        testController.AddNote(note2);

        var result = testController.GetNote(1);
        Console.WriteLine($"{result.Id}:{result.Content}-{ result.Title}");

        note2.Title ="New";
        note2.Content = "New";
        testController.UpdateNote(note2);

        testController.RemoveNote(note1);

        var notes = testController.GetAllNotes();
        foreach (var note in notes)
        {
            Console.WriteLine($"{note.Id} : {note.Title} {note.Content}");
        }
    }
}