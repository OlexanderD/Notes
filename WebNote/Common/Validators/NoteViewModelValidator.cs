using FluentValidation;
using NoteApp.DataAccess.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebNote.ViewModels;

namespace NoteApp.ConsoleUI.Common.Validators
{
    public class NoteViewModelValidator:AbstractValidator<NoteViewModels>
    {

       public NoteViewModelValidator()
        {
            RuleFor(x =>x.Title).NotEmpty();

            RuleFor(x =>x.Title).MaximumLength(15);

            RuleFor(x =>x.Content).MaximumLength(50);
        }

    }
}
