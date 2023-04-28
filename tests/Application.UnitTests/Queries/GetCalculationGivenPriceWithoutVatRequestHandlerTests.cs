using FluentAssertions;
using VatCalculator.Application.Queries.GetVatCalculationQuery;
using VatCalculator.Domain.Common;
using Xunit;

namespace VatCalculator.Application.UnitTests.Queries;

public class GetCalculationGivenPriceWithoutVatRequestHandlerTests
{

    [Theory]
    [InlineData(10, 250.00, 0, 0, 25.00, 250.00, 275.00)]
    [InlineData(13, 250.00, 0, 0, 32.50, 250.00, 282.50)]
    [InlineData(20, 250.00, 0, 0, 50.00, 250.00, 300.00)]
    public async Task Handle_Should_ReturnSuccess_When_CombiningInputValues(
        decimal vatRate, decimal priceWithoutVat, decimal vat, decimal priceWithVat
        , decimal expectedVat, decimal expectedPriceWithoutVat, decimal expectedPriceWithVat)
    {
        // arrange
        var query = new GetCalculationGivenPriceWithoutVatRequest();
        query.VatRate = vatRate;
        query.PriceWithoutVat = priceWithoutVat;
        query.Vat = vat;
        query.PriceWithVat = priceWithVat;

        var handler = new GetCalculationGivenPriceWithoutVatRequestHandler();

        // act
        Result<GetVatCalculationResponse> result = await handler.Handle(query, default);

        // assert
        result.IsFailure.Should().BeFalse();
        result.Value.Vat.Should().Be(expectedVat);
        result.Value.PriceWithoutVat.Should().Be(expectedPriceWithoutVat);
        result.Value.PriceWithVat.Should().Be(expectedPriceWithVat);

    }

}
