using VatCalculator.Application.Services.Abstractions;
using VatCalculator.Domain.Common;
using VatCalculator.Domain.Entities;

namespace VatCalculator.Application.Services;

public class CalculationGivenPriceWithoutVatService : ICalculationService
{
    public Result<Calculation> Calculate(Calculation input)
    {

        var response = new Calculation()
        {
            VatRate = input.VatRate,
            PriceWithoutVat = input.PriceWithoutVat,
            PriceWithVat = -(-input.PriceWithoutVat - input.PriceWithoutVat * (input.VatRate / 100)),
            Vat = -(-input.PriceWithoutVat - input.PriceWithoutVat * (input.VatRate / 100)) - input.PriceWithoutVat,
        };

        return response;
    }

}

