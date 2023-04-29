using FluentAssertions;
using VatCalculator.Application.Common;
using VatCalculator.Application.Queries.GetVatCalculationQuery;
using VatCalculator.Domain.Common;
using Xunit;

namespace VatCalculator.Application.Queries.UnitTests;

public class GetCalculationGivenVatRequestHandlerTests
{

    [Theory]
    [InlineData(10, 0, 25.00, 0, 25.00, 250.00, 275.00)]
    [InlineData(13, 0, 32.50, 0, 32.50, 250.00, 282.50)]
    [InlineData(20, 0, 50.00, 0, 50.00, 250.00, 300.00)]
    public async Task Handle_Should_ReturnSuccess_When_CombiningInputValues(
        decimal vatRate, decimal priceWithoutVat, decimal vat, decimal priceWithVat
        , decimal expectedVat, decimal expectedPriceWithoutVat, decimal expectedPriceWithVat)
    {
        // arrange
        var query = new GetCalculationGivenVatRequest();
        query.VatRate = vatRate;
        query.PriceWithoutVat = priceWithoutVat;
        query.Vat = vat;
        query.PriceWithVat = priceWithVat;

        var handler = new GetCalculationGivenVatRequestHandler();

        // act
        Result<GetVatCalculationResponse> result = await handler.Handle(query, default);

        // assert
        result.IsFailure.Should().BeFalse();
        result.Value.Vat.Should().Be(expectedVat);
        result.Value.PriceWithoutVat.Should().Be(expectedPriceWithoutVat);
        result.Value.PriceWithVat.Should().Be(expectedPriceWithVat);

    }

}
