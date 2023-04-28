using VatCalculator.Domain.Common;
using VatCalculator.Domain.Entities;

namespace VatCalculator.Application.Services.Abstractions;

public interface ICalculationService
{
    Result<Calculation> Calculate(Calculation input);

}

