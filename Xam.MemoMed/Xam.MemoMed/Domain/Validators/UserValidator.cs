using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xam.MemoMed.Domain.Models;

namespace Xam.MemoMed.Domain.Validators
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(user => user.Name)
                .NotEmpty()
                .WithMessage("Naam is verplicht");

            RuleFor(user => user.Email)
                .NotEmpty()
                .WithMessage("Email is verplicht")
                .EmailAddress()
                .WithMessage("Geen geldig e-mailadres");

            RuleFor(user => user.Phone)
                .NotEmpty()
                .WithMessage("Telefoon is verplicht");
                //.Matches(@"(?:(?:(\s*\(?([2-9]1[02-9]|[2-9][02-8]1|[2-9][02-8][02-9])\s*)|([2-9]1[02-9]|[2‌​-9][02-8]1|[2-9][02-8][02-9]))\)?\s*(?:[.-]\s*)?)([2-9]1[02-9]|[2-9][02-9]1|[2-9]‌​[02-9]{2})\s*(?:[.-]\s*)?([0-9]{4})")
                //.WithMessage("Geen geldig telefoonnummer");

        }
    }
}
