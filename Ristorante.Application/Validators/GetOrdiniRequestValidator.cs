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
            RuleFor(r => r.DataInizio)
                .Must(r => r <= DateTime.Now)
                .WithMessage("La data di fine è oltre quella attuale");
            
            RuleFor(r => r)
                .Must(r => r.DataFine >= r.DataInizio)
                .WithMessage("La data di fine non può essere successiva alla data di inizio");
            
            RuleFor(r => r.PageSize)
                .Must(r => r > 0)
                .WithMessage("Inserire almeno un risultato per pagina");

        }

    }
}
