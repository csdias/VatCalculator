using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace VatCalculator.WebApp.IntegrationTests.Controllers
{
    public class VatCalculationsControllerTests: IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly WebApplicationFactory<Program> _factory;

        public VatCalculationsControllerTests(WebApplicationFactory<Program> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task GetVatCalculation_WhenInputIsCorrect_Then_Result_Should_BeOk()
        {
            // arrange
            using var client = _factory.CreateClient();
            var vatRate = 10;
            var priceWithoutVat = 250;

            // act
            var response = await client.GetAsync($"api/vat-calculations?vatRate={vatRate}&priceWithoutVat={priceWithoutVat}");

            // assert
            response.EnsureSuccessStatusCode(); // Status Code 200-299
            response.Content.Headers.ContentType.ToString().Should().Be("application/json; charset=utf-8");       
        }

        [Fact]
        public async Task GetVatCalculation_WhenValRateIsZero_Then_Result_Should_BeBadRequest()
        {
            // arrange
            using var client = _factory.CreateClient();
            var vatRate = 0;

            // act
            var response = await client.GetAsync($"api/vat-calculations?vatRate={vatRate}");

            // assert
            response.StatusCode = System.Net.HttpStatusCode.BadRequest;
        }

        [Fact]
        public async Task GetVatCalculation_WhenValRateIsMissing_Then_Result_Should_BeBadRequest()
        {
            // arrange
            using var client = _factory.CreateClient();
            var priceWithoutVat = 250;

            // act
            var response = await client.GetAsync($"api/vat-calculations?priceWithoutVat={priceWithoutVat}");

            // assert
            response.StatusCode = System.Net.HttpStatusCode.BadRequest;
        }

        [Fact]
        public async Task GetVatCalculation_WhenValRateIsInvalid_Then_Result_Should_BeBadRequest()
        {
            // arrange
            using var client = _factory.CreateClient();
            var vatRate = 5;
            var priceWithoutVat = 250;

            // act
            var response = await client.GetAsync($"api/vat-calculations?vatRate={vatRate}&priceWithoutVat={priceWithoutVat}");

            // assert
            response.StatusCode = System.Net.HttpStatusCode.BadRequest;
        }

        [Fact]
        public async Task GetVatCalculation_WhenMoreThanCorrectValuesAreSent_Then_Result_Should_BeBadRequest()
        {
            // arrange
            using var client = _factory.CreateClient();

            var vatRate = 10;
            var vat = 25;
            var priceWithoutVat = 250;

            // act
            var response = await client.GetAsync($"api/vat-calculations?vatRate={vatRate}&priceWithoutVat={priceWithoutVat}");

            // assert
            response.StatusCode = System.Net.HttpStatusCode.BadRequest;
        }

        [Fact]
        public async Task GetVatCalculation_WhenInputIsIncomplete_Then_Result_Should_BeBadRequest()
        {
            // arrange
            using var client = _factory.CreateClient();
            var vatRate = 20;

            // act
            var response = await client.GetAsync($"api/vat-calculations?vatRate={vatRate}");

            // assert
            response.StatusCode = System.Net.HttpStatusCode.BadRequest;
        }
    }
}
