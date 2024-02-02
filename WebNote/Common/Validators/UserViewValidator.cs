using FluentValidation;
using WebNote.ViewModels;

namespace WebNote.Common.Validators
{
    public class UserViewValidator:AbstractValidator<UserViewModel>
    {

       public UserViewValidator()
        {
            RuleFor(x => x.UserName).NotEmpty()
                .MaximumLength(50)
                .MinimumLength(3);

            RuleFor(x => x.Password).NotEmpty()
                .MinimumLength(8);
        }

    }
}
