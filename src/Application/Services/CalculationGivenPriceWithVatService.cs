using MediatR;
using VatCalculator.Application.Services.Abstractions;
using VatCalculator.Domain.Common;
using VatCalculator.Domain.Entities;

namespace VatCalculator.Application.Services;

public class CalculationGivenPriceWithVatService : ICalculationService
{
    public Result<Calculation> Calculate(Calculation input)
    {

        var response = new Calculation()
        {
            VatRate = input.VatRate,
            PriceWithVat = input.PriceWithVat,
            PriceWithoutVat = input.PriceWithVat / (1 + input.VatRate / 100),
            Vat = input.PriceWithVat / (1 + input.VatRate / 100) * (input.VatRate / 100)
        };

        return response;
    }

}

