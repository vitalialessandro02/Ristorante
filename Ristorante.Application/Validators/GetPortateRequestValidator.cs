using FluentValidation;
using Ristorante.Application.Models.Requests;
using Ristorante.Models.Enumeration;

namespace Ristorante.Application.Validators
{
    public class GetPortateRequestValidator : AbstractValidator<GetPortateRequest>
    {
        public GetPortateRequestValidator() 
        {
            RuleFor(r => r.PageSize)
                .Must(r => r > 0)
                .WithMessage("Dev'essere visto almeno un risultato per pagina");
            
            RuleFor(r => r.TipologiaPortate)
                .Must(r => Enum.IsDefined(typeof(Tipologia), r))
                .WithMessage("Tipologia non presente");
        }
    }
}
