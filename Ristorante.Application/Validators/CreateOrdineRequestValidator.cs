using Castle.Core.Internal;
using FluentValidation;
using Ristorante.Application.Models.Requests;
using Ristorante.Models.Context;
using Ristorante.Models.Repositories;

namespace Ristorante.Application.Validators
{
    public class CreateOrdineRequestValidator : AbstractValidator<CreateOrdineRequest>
    {
        private readonly UtenteRepository _utenteRepository = new UtenteRepository(new MyDbContext());
        private readonly PortataRepository _portataRepository = new PortataRepository(new MyDbContext());
        public CreateOrdineRequestValidator()
        {
            RuleFor(r => r.Email)
                .NotEmpty()
                .WithMessage("Il campo email è obbligatorio")
                .NotNull()
            .WithMessage("Il campo email non può essere nullo")
                .Must(r => _utenteRepository.GetIdUtenteByEmail(r) != -1)
                .WithMessage("Utente non presente");
            RuleFor(r => r)
                .Must(r => r.Portate.Count == r.Quantita.Count && !r.Portate.IsNullOrEmpty())
                .WithMessage("Il numero di portate inserite dev'essere uguale alle quantita' di ciascuna portata");
            RuleFor(r => r.Portate)
                .Must(r => _portataRepository.PortateExists(r))
                .WithMessage("Alcune portate selezionate non esistono");
        }
    }
}
