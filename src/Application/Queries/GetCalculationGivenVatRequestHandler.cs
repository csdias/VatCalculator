using MediatR;
using VatCalculator.Application.Common;
using VatCalculator.Domain.Common;

namespace VatCalculator.Application.Queries.GetVatCalculationQuery;

public class GetCalculationGivenVatRequestHandler 
            : IRequestHandler<GetCalculationGivenVatRequest, Result<GetVatCalculationResponse>>
{

    public async Task<Result<GetVatCalculationResponse>> Handle(
                        GetCalculationGivenVatRequest request,
                        CancellationToken cancellationToken)
    {
        return new GetVatCalculationResponse()
        {
            VatRate = request.VatRate,
            Vat = request.Vat,
            PriceWithoutVat = request.Vat / (request.VatRate / 100),
            PriceWithVat = (request.Vat / (request.VatRate / 100)) + request.Vat
        };
    }
}
