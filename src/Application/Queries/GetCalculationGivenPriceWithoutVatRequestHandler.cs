using MediatR;
using VatCalculator.Domain.Common;
using VatCalculator.Application.Common;

namespace VatCalculator.Application.Queries.GetVatCalculationQuery;

public class GetCalculationGivenPriceWithoutVatRequestHandler 
            : IRequestHandler<GetCalculationGivenPriceWithoutVatRequest, Result<GetVatCalculationResponse>>
{

    public async Task<Result<GetVatCalculationResponse>> Handle(
                        GetCalculationGivenPriceWithoutVatRequest request,
                        CancellationToken cancellationToken)
    {
        return new GetVatCalculationResponse()
        {
            VatRate = request.VatRate,
            PriceWithoutVat = request.PriceWithoutVat,
            PriceWithVat = -(-request.PriceWithoutVat - (request.PriceWithoutVat * (request.VatRate / 100))),
            Vat = -(-request.PriceWithoutVat - (request.PriceWithoutVat * (request.VatRate / 100))) - request.PriceWithoutVat,
        };    
    }
}
