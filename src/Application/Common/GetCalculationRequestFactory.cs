using VatCalculator.Application.Queries.GetVatCalculationQuery;
using VatCalculator.Application.Common.Abstractions;

namespace VatCalculator.Application.Common;

public class GetCalculationRequestFactory : IGetCalculationRequestFactory
{
    public GetVatCalculationRequest GetInstance(GetVatCalculationInput input)
    {
        return input switch
        {
            { PriceWithoutVat: > 0 }
                    => new GetCalculationGivenPriceWithoutVatRequest(),

            { Vat: > 0 }
                    => new GetCalculationGivenVatRequest(),

            { PriceWithVat: > 0 }
                    => new GetCalculationGivenPriceWithVatRequest(),

            { } => throw new Exception("Couldn't instanciate the calculator."),

            null => throw new ArgumentNullException(nameof(input), "Couldn't instanciate the calculator.")

        };
    }
}