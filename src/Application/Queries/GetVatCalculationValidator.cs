using FluentValidation;
using VatCalculator.Application.Queries.GetVatCalculationQuery;

namespace Gatherly.Application.Members.Commands.CreateMember;
internal class GetVatCalculationValidator : AbstractValidator<GetVatCalculationRequest>
{
    public GetVatCalculationValidator()
    {
        RuleFor(x => x.VatRate).GreaterThan(0);

        RuleFor(x => x).Custom((x, context) => {
            if (x.PriceWithoutVat == 0 && x.Vat == 0 && x.PriceWithVat == 0)
            {
                context.AddFailure("There must be at least one item among VAT, Price Without VAT and Price With VAT");
            }
        });
    }
}
