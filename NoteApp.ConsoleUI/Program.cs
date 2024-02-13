using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NoteApp.BusinessLogic.Inrerfaces;
using NoteApp.BusinessLogic.Services;
using NoteApp.ConsoleUI.Common.Helpers;
using NoteApp.ConsoleUI.Controllers;
using NoteApp.Data.Data.Models;
using NoteApp.Data.Interfaces;
using NoteApp.Data.Repositories;
using NoteApp.DataAccess.Data;
using NoteApp.DataAccess.Data.Models;
using NoteApp.DataAccess.Interfaces;
using NoteApp.DataAccess.Repositories.NoteApp.DataAccess.Repositories;
using System.Numerics;

internal class Program
{
    private static void Main(string[] args)
    {

        var config = ConfigurationHelper.SetupConfiguration();
        var serviceProvider = ServiceHelper.BuildServiceProvider(config);

        

        UserController userController =serviceProvider.GetRequiredService<UserController>();

        NoteController noteController=serviceProvider.GetRequiredService<NoteController>();

        while (true)
        {

            Console.WriteLine("Choose option:");
            Console.WriteLine("1. Registration");
            Console.WriteLine("2. Login");
            Console.WriteLine("3. Leave");


            int choice = int.Parse(Console.ReadLine());


            switch (choice)
            {
                case 1:

                    Console.WriteLine("Enter UserName:");
                    string username = Console.ReadLine();

                    Console.WriteLine("Enter password:");
                    string password = Console.ReadLine();

                    //User user = new User {Password=password,UserName=username};

                    bool success = userController.UserRegistration(user);
                     

                    if (success)
                    {
                        Console.WriteLine("User succesfully registered");
                    }
                    else
                    {
                        Console.WriteLine("User already exists ");
                    }

                    break;

                case 2:

                    Console.WriteLine("Enter UserName:");
                    username = Console.ReadLine();

                    Console.WriteLine("Enter Password:");
                    password = Console.ReadLine();

                    User? user1 = userController.UserLogin(username, password);
                    

                    if (user1 != null)
                    {
                        //int userid=user1.Id;
                        Console.WriteLine("User succesfully enters ");
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
                                var notes = noteController.GetAllNotes(userid);

                                foreach (var note in notes)
                                {
                                    Console.WriteLine($"ID: {note.Id}\n" +
                                  $"Title: {note.Title}\n" +
                                  $"Content: {note.Content}");

                                }
                                if (notes.Count != 0)
                                {
                                    Console.WriteLine("Operation succesful");
                                }
                                Console.ReadLine();

                            }
                            else if (menu == 2)
                            {
                                Console.WriteLine("Creating new note");
                                Note note = new Note();
                                Console.WriteLine("Enter Title");
                                note.Title = Console.ReadLine();
                                Console.WriteLine("Enter Content");
                                note.Content = Console.ReadLine();

                                note.UserId = userid;

                                noteController.AddNote(note);
                                Console.WriteLine("Operation succesful");
                                Console.ReadLine();
                            }
                            else if (menu == 3)
                            {
                                Console.WriteLine("Update your Note");
                                var notes = noteController.GetAllNotes(userid);

                                foreach (var note in notes)
                                {
                                    Console.WriteLine($"Existing notes\n:ID: {note.Id}");
                                }
                                Console.WriteLine("Enter Note Id");
                                int id;
                                Int32.TryParse(Console.ReadLine(), out id);

                                Note existingNote = noteController.GetNote(id);
                                if (existingNote != null && userid == existingNote.Id)
                                {
                                    Note updatedNote = new Note();
                                    updatedNote.Id = id;

                                    Console.WriteLine("Enter new title:");
                                    updatedNote.Title = Console.ReadLine();
                                    Console.WriteLine("Enter new content:");
                                    updatedNote.Content = Console.ReadLine();
                                    noteController.UpdateNote(updatedNote);
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
                                var notes = noteController.GetAllNotes(userid);

                                foreach (var note1 in notes)
                                {
                                    Console.WriteLine($"Existing notes\n:ID: {note1.Id}");
                                }
                                Console.WriteLine("Enter Note ID");
                                int id;
                                Int32.TryParse(Console.ReadLine(), out id);

                                Note note = noteController.GetNote(id);

                                if (note != null && userid == note.Id)
                                {
                                    noteController.RemoveNote(note);
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

                    else
                    {
                        Console.WriteLine("Неверный логин или пароль");
                    }

                    break;

                case 3:

                    Console.WriteLine("Выход");
                    return;

                default:

                    Console.WriteLine("Неизвестный выбор");
                    break;
            }
        }
    }
}





