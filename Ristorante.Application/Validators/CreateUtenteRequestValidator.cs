using FluentValidation;
using Ristorante.Application.Extensions;
using Ristorante.Application.Models.Requests;
using Ristorante.Models.Context;
using Ristorante.Models.Entities;
using Ristorante.Models.Repositories;

namespace Ristorante.Application.Validators
{
    public class CreateUtenteRequestValidator : AbstractValidator<CreateUtenteRequest>
    {
        private readonly UtenteRepository _utenteRepository = new UtenteRepository(new MyDbContext());
        public CreateUtenteRequestValidator()
        {
            RuleFor(r => r.Nome)
                .NotEmpty()
                .WithMessage("Il campo nome è obbligatorio")
                .NotNull()
                .WithMessage("Il campo nome non può essere nullo");
            
            RuleFor(r => r.Cognome)
                .NotEmpty()
                .WithMessage("Il campo cognome è obbligatorio")
                .NotNull()
                .WithMessage("Il campo cognome non può essere nullo");
            
            RuleFor(r => r.Email)
                .NotEmpty()
                .WithMessage("Il campo email è obbligatorio")
                .NotNull()
                .WithMessage("Il campo email non può essere nullo")
                .Must(r => _utenteRepository.GetIdUtenteByEmail(r) == -1)
                .WithMessage("Email già presente");
            
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
        }

    }
}
