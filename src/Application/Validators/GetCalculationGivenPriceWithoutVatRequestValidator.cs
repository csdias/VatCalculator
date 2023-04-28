using FluentValidation;
using VatCalculator.Application.Queries.GetVatCalculationQuery;

namespace VatCalculator.Application.Validators;

public class GetCalculationGivenPriceWithoutVatRequestValidator : AbstractValidator<GetCalculationGivenPriceWithoutVatRequest>
{
    public GetCalculationGivenPriceWithoutVatRequestValidator()
    {
        RuleFor(x => x).Custom((x, context) =>
        {
            if (x.VatRate != 10 && x.VatRate != 13 && x.VatRate != 20)
            {
                context.AddFailure("Invalid VAT rate. Please, choose a value between 10, 13 and 20.");
            }
        });

        RuleFor(x => x).Custom((x, context) =>
        {
            if (x.PriceWithoutVat != 0 && x.Vat != 0
                || x.PriceWithoutVat != 0 && x.PriceWithVat != 0
                || x.Vat != 0 && x.PriceWithVat != 0)
            {
                context.AddFailure("More than one value error. Please enter only one value between VAT, Price without VAT and Price with VAT.");
            }
        });

        RuleFor(x => x).Custom((x, context) =>
        {
            if (x.PriceWithoutVat == 0 && x.Vat == 0 && x.PriceWithVat == 0)
            {
                context.AddFailure("There must be at least one value between VAT, Price without VAT and Price with VAT");
            }
        });
    }
}
