using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Configuration;
using NoteApp.BusinessLogic.Services;
using NoteApp.ConsoleUI.Common.Helpers;
using NoteApp.ConsoleUI.Controllers;
using NoteApp.DataAccess.Data;
using NoteApp.DataAccess.Data.Models;
using NoteApp.DataAccess.Repositories.NoteApp.DataAccess.Repositories;

internal class Program
{
    private static void Main(string[] args)
    {
        var config = ConfigurationHelper.SetupConfiguration();

        var connectionString = config.GetConnectionString("DefaultConnetion");

        var optionsBuilder = new DbContextOptionsBuilder<TestContext>();
        var options = optionsBuilder.UseSqlite(connectionString).Options;

        using var context = new TestContext(options);
        var noteRepository = new NoteRepository(context);
        var noteService = new NoteService(noteRepository);
        var testController = new NoteController(noteService);
        context.Database.EnsureDeleted();
        context.Database.EnsureCreated();
        do
        {
            Console.WriteLine(" # # # # # Notes App # # # # #");
            Console.WriteLine("1 - View Notes | 2 - Create Note | 3 - Update Note | 4 - Delete Note | 0 - Exit");

            int menu;
            Int32.TryParse(Console.ReadLine(), out menu);
            Console.Clear();

            if (menu == 1)
            {
                Console.WriteLine("Your notes");
                var notes = testController.GetAllNotes();
                
                foreach (var note in notes)
                {
                    Console.WriteLine($"ID: {note.Id}\n" +
                  $"Title: {note.Title}\n" +
                  $"Content: {note.Content}");

                }
                if(notes.Count != 0)
                {
                    Console.WriteLine("Operation succesful");
                }
                Console.ReadLine();

            }
            else if (menu == 2)
            {
                Console.WriteLine("Creating new note");
                Note note = new Note();

                Console.WriteLine("Enter Id");
                int id;
                Int32.TryParse(Console.ReadLine(), out id);
                note.Id = id;
                Console.WriteLine("Enter Title");
                note.Title = Convert.ToString(Console.ReadLine());
                Console.WriteLine("Enter Content");
                note.Content = Convert.ToString(Console.ReadLine());

                testController.AddNote(note);
                Console.WriteLine("Operation succesful");
                Console.ReadLine();
            }
            else if (menu == 3)
            {
                Console.WriteLine("Update your Note");
                var notes = testController.GetAllNotes();

                foreach (var note in notes)
                {
                    Console.WriteLine($"Existing notes\n:ID: {note.Id}");
                }
                Console.WriteLine("Enter Note Id");
                int id;
                Int32.TryParse(Console.ReadLine(), out id);

                Note existingNote = testController.GetNote(id);
                if (existingNote != null)
                {
                    Note updatedNote = new Note();
                    updatedNote.Id = id;

                    Console.WriteLine("Enter new title:");
                    updatedNote.Title = Convert.ToString(Console.ReadLine());
                    Console.WriteLine("Enter new content:");
                    updatedNote.Content = Convert.ToString(Console.ReadLine());
                    testController.UpdateNote(updatedNote);
                    Console.WriteLine("Operation succesful");
                }
                else
                {
                    Console.WriteLine("Note not found!");
                }
            }
            else if (menu == 4)
            {
                Console.WriteLine("Delete your Note");
                Console.WriteLine("Enter Note ID");
                int id;
                Int32.TryParse(Console.ReadLine(), out id);

                Note note = testController.GetNote(id);

                if (note != null)
                {
                    testController.RemoveNote(note);
                    Console.WriteLine("Operation succesful");
                }
                else
                {
                    Console.WriteLine("Note not found!");
                }
            }
            else if (menu == 0)
            {
                break;
                
            }

        } while (true);
    }
}