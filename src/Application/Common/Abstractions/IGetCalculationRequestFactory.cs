using MediatR;
using VatCalculator.Application.Queries.GetVatCalculationQuery;
using VatCalculator.Domain.Common;
using VatCalculator.Domain.Entities;

namespace VatCalculator.Application.Services.Abstractions;

public interface IGetCalculationRequestFactory
{
    GetVatCalculationRequest GetInstance(GetVatCalculationInput input);

}