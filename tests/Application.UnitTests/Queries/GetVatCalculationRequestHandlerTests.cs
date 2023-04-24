using FluentAssertions;
using VatCalculator.Application.Queries.GetVatCalculationQuery;
using VatCalculator.Domain.Common;
using Xunit;

namespace VatCalculator.Application.UnitTests.Queries;

public class GetVatCalculationRequestHandlerTests
{

    public GetVatCalculationRequestHandlerTests()
    {
    }

    [Theory]
    [InlineData(10, 250.00, 0, 0, 25, 275)]
    [InlineData(13, 250.00, 0, 0, 32.5, 282.5)]
    [InlineData(20, 250.00, 0, 0, 50, 300)]
    public async Task Handle_Should_ReturnSuccess_When_CombiningInputValues(
        decimal vatRate, decimal priceWithoutVat, decimal vat, decimal priceWithVat
        , decimal expectedVat, decimal expectedPriceWithVat)
    {
        // Arrange
        var query = new GetVatCalculationRequest();
        query.VatRate = vatRate;
        query.PriceWithoutVat = priceWithoutVat;
        query.Vat = vat;
        query.PriceWithVat = priceWithVat;

        var handler = new GetVatCalculationRequestHandler();

        // Act
        Result<GetVatCalculationResponse> result = await handler.Handle(query, default);

        // Assert
        result.IsFailure.Should().BeFalse();
        result.Value.Vat.Should().Be(expectedVat);
        result.Value.PriceWithVat.Should().Be(expectedPriceWithVat);

    }

}
