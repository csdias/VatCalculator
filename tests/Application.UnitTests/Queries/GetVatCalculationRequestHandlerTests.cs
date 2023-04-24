using FluentAssertions;
using VatCalculator.Application.Queries.GetVatCalculationQuery;
using VatCalculator.Domain.Common;
using Moq;
using Xunit;

namespace VatCalculator.Application.UnitTests.Queries;

public class GetVatCalculationRequestHandlerTests
{

    public GetVatCalculationRequestHandlerTests()
    {
    }

    [Fact]
    public async Task Handle_Should_ReturnFailureResult_WhenVatRateIsZero()
    {
        // Arrange
        var query = new GetVatCalculationRequest();
        query.VatRate = 0;

        var response = new GetVatCalculationResponse();

        var handler = new GetVatCalculationRequestHandler();

        // Act
        Result<GetVatCalculationResponse> result = await handler.Handle(query, default);

        // Assert
        result.IsFailure.Should().BeTrue();
        result.Error.Should().Be("Error");
    }

    [Fact]
    public async Task Handle_Should_ReturnFailureResult_WhenPriceWithoutVatPriceWithVatAndVatAreZero()
    {
        // Arrange
        var query = new GetVatCalculationRequest();
        query.VatRate = 5;
        query.Vat = 0;
        query.PriceWithoutVat = 0;
        query.PriceWithVat = 0;

        var response = new GetVatCalculationResponse();

        var handler = new GetVatCalculationRequestHandler();

        // Act
        Result<GetVatCalculationResponse> result = await handler.Handle(query, default);

        // Assert
        result.IsFailure.Should().BeTrue();
        result.Error.Should().Be("Error");
    }

    [Fact]
    public async Task Handle_Should_ReturnSuccess_WhenVarRateAndPriceWithoutVatAreSent()
    {
        // Arrange
        var query = new GetVatCalculationRequest();
        query.VatRate = 5;
        query.PriceWithoutVat = 250.00m;

        var response = new GetVatCalculationResponse();
        response.Vat = 12.5m;
        response.PriceWithVat = 262.5m;

        var handler = new GetVatCalculationRequestHandler();

        // Act
        Result<GetVatCalculationResponse> result = await handler.Handle(query, default);

        // Assert
        result.IsFailure.Should().BeFalse();
        result.Value.PriceWithVat.Should().Be(response.Vat);
    }

}
