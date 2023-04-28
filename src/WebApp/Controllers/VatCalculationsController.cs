using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using VatCalculator.Application.Queries.GetVatCalculationQuery;
using VatCalculator.Domain.Common;
using VatCalculator.Application.Services.Abstractions;
using VatCalculator.Domain.Entities;

namespace VatCalculator.App.Controllers
{
    [Route("api/vat-calculations")]
    public class VatCalculationsController: ApiController
    {
        private readonly ILogger<VatCalculationsController> _logger;
        private readonly ICalculationServiceFactory _factory;

        public VatCalculationsController(ILogger<VatCalculationsController> logger
            , ICalculationServiceFactory factory)
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-Us");
            _logger = logger;
            _factory = factory;
        }

        [HttpGet()]
        public async Task<IActionResult> Get(
                [FromQuery] GetVatCalculationRequest getVatCalculationRequest
                , CancellationToken cancellationToken)
        {

            // Strategy with DI call example
            var input = new Calculation();
            input.Vat = getVatCalculationRequest.Vat;
            input.VatRate = getVatCalculationRequest.VatRate;
            input.PriceWithoutVat = getVatCalculationRequest.PriceWithoutVat;
            input.PriceWithVat = getVatCalculationRequest.PriceWithVat;

            var calculationService = _factory.GetInstance(input);

            var res = calculationService.Calculate(input);


            // Mediatr call example
            Result<GetVatCalculationResponse> response = await Mediator.Send(
                getVatCalculationRequest,
                cancellationToken);

            if (response.IsFailure)
            {
                return HandleFailure(response);
            }

            return Ok(response.Value);
        }
    }
}