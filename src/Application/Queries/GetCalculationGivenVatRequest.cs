using VatCalculator.Application.Common.Abstractions;

namespace VatCalculator.Application.Queries.GetVatCalculationQuery;

public class GetCalculationGivenVatRequest : GetVatCalculationRequest
{
    public override decimal VatRate { get; set; }

    public override decimal PriceWithoutVat { get; set; }

    public override decimal Vat { get; set; }

    public override decimal PriceWithVat { get; set; }
}

