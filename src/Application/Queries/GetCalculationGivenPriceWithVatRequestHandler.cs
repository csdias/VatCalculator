using MediatR;
using VatCalculator.Application.Common;
using VatCalculator.Domain.Common;

namespace VatCalculator.Application.Queries.GetVatCalculationQuery;

public class GetCalculationGivenPriceWithVatRequestHandler 
            : IRequestHandler<GetCalculationGivenPriceWithVatRequest, Result<GetVatCalculationResponse>>
{

    public async Task<Result<GetVatCalculationResponse>> Handle(
                        GetCalculationGivenPriceWithVatRequest request,
                        CancellationToken cancellationToken)
    {
        return new GetVatCalculationResponse() 
        {
            VatRate = request.VatRate,
            PriceWithVat = request.PriceWithVat,
            PriceWithoutVat = request.PriceWithVat / (1 + (request.VatRate / 100)),
            Vat = (request.PriceWithVat / (1 + (request.VatRate / 100))) * (request.VatRate / 100)
        };
    }
}
