using MediatR;
using VatCalculator.Application.Services.Abstractions;
using VatCalculator.Domain.Common;
using VatCalculator.Domain.Entities;

namespace VatCalculator.Application.Services;

public class CalculationGivenVatService : ICalculationService
{
    public Result<Calculation> Calculate(Calculation input)
    {

        var response = new Calculation()
        {
            VatRate = input.VatRate,
            Vat = input.Vat,
            PriceWithoutVat = input.Vat / (input.VatRate / 100),
            PriceWithVat = input.Vat / (input.VatRate / 100) + input.Vat
        };

        return response;
    }

}

