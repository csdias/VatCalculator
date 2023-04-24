using FluentAssertions;
using MediatR;
using VatCalculator.Application.Queries.GetVatCalculationQuery;
using Xunit;

namespace VatCalculator.Application.IntegrationTests.Queries;


public class GetVatCalculationRequestTest
{
    [Fact]
    public async Task Should()
    {
        var query = new GetVatCalculationRequest();

        //var result = await Mediator.Send(query);

        //result.Should()
    }

}
