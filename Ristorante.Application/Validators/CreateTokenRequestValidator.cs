using FluentValidation;
using System.Text.RegularExpressions;
using Ristorante.Application.Extensions;
using Ristorante.Application.Models.Requests;
using Ristorante.Models.Context;
using Ristorante.Models.Repositories;

namespace Ristorante.Application.Validators
{
    public class CreateTokenRequestValidator : AbstractValidator<CreateTokenRequest>
    {
        private readonly UtenteRepository _utenteRepository = new UtenteRepository(new MyDbContext());

        public CreateTokenRequestValidator()
        {
            RuleFor(r => r.Username)
                .NotEmpty()
                .WithMessage("Il campo username è obbligatorio")
                .NotNull()
                .WithMessage("Il campo username non può essere nullo");

            RuleFor(r => r.Password)
                .NotEmpty()
                .WithMessage("Il campo password è obbligatorio")
                .NotNull()
                .WithMessage("Il campo password non può essere nullo")
                .MinimumLength(6)
                .WithMessage("Il campo password deve essere almeno lungo 6 caratteri")
                .RegEx("^(?=.*[A-Z])(?=.*[a-z])(?=.*\\d)(?=.*[!@#$%^&*()_+{}\\[\\]:;<>,.?~\\\\-]).{6,}$"
                , "Il campo password deve essere lungo almeno 6 caratteri e deve contenere almeno un carattere maiuscolo, uno minuscolo, un numero e un carattere speciale"
                );
            
            RuleFor(r => r)
                .Must(r => _utenteRepository.GetIdUtenteByCredentials(r.Username, r.Password) != -1)
                .WithMessage("Utente non esistente");
        }
    }
}
