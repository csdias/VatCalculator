namespace VatCalculator.Application.Common.Abstractions;

public interface IGetCalculationRequestFactory
{
    GetVatCalculationRequest GetInstance(GetVatCalculationInput input);

}