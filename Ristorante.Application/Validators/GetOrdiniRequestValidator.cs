using FluentValidation;
using Ristorante.Application.Models.Requests;
using Ristorante.Models.Context;
using Ristorante.Models.Repositories;

namespace Ristorante.Application.Validators
{
    public class GetOrdiniRequestValidator : AbstractValidator<GetOrdiniRequest>
    {
        private readonly UtenteRepository _utenteRepository = new UtenteRepository(new MyDbContext());
        public GetOrdiniRequestValidator()
        {
            RuleFor(r => r.Email)
                .NotEmpty()
                .WithMessage("Il campo email è obbligatorio")
                .NotNull()
                .WithMessage("Il campo email non può essere nullo")
                .Must(r => _utenteRepository.GetIdUtenteByEmail(r) != -1)
                .WithMessage("Utente non presente");
            
            RuleFor(r => r.dataInizio)
                .Must(r => r <= DateTime.Now)
                .WithMessage("La data di fine è oltre quella attuale");
            
            RuleFor(r => r)
                .Must(r => r.dataFine >= r.dataInizio)
                .WithMessage("La data di fine non può essere successiva alla data di inizio");
            
            RuleFor(r => r.PageSize)
                .Must(r => r > 0)
                .WithMessage("Inserire almeno un risultato per pagina");
        }

    }
}
