using MediatR;
using VatCalculator.Domain.Common;

namespace VatCalculator.Application.Common.Abstractions;

public abstract class GetVatCalculationRequest : IRequest<Result<GetVatCalculationResponse>>
{
    public abstract decimal VatRate { get; set; }

    public abstract decimal PriceWithoutVat { get; set; }

    public abstract decimal Vat { get; set; }

    public abstract decimal PriceWithVat { get; set; }
}

