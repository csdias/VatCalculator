using VatCalculator.Domain.Entities;

namespace VatCalculator.Application.Services.Abstractions;

public interface ICalculationServiceFactory
{
    ICalculationService GetInstance(Calculation calculation);

}