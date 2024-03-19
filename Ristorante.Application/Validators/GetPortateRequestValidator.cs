using FluentValidation;
using Ristorante.Application.Models.Requests;

namespace Ristorante.Application.Validators
{
    public class GetPortateRequestValidator : AbstractValidator<GetPortateRequest>
    {
        public GetPortateRequestValidator() 
        {
            RuleFor(r => r.PageSize)
                .Must(r => r > 0)
                .WithMessage("Dev'essere visto almeno un risultato per pagina");
        }
    }
}
