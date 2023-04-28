using VatCalculator.Application.Services.Abstractions;
using VatCalculator.Domain.Entities;

namespace VatCalculator.Application.Services;

public class CalculationServiceFactory : ICalculationServiceFactory
{
    public ICalculationService GetInstance(Calculation request)
    {
        return request switch
        {
            { PriceWithoutVat: > 0 }
                    => new CalculationGivenPriceWithoutVatService(),

            { Vat: > 0 }
                    => new CalculationGivenVatService(),

            { PriceWithVat: > 0 }
                    => new CalculationGivenPriceWithVatService(),

            { } => throw new Exception("Couldn't instanciate the calculator."),

            null => throw new ArgumentNullException(nameof(request), "Couldn't instanciate the calculator.")

        };
    }
}