using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using VatCalculator.Application.Common;
using VatCalculator.Application.Common.Abstractions;
using VatCalculator.Domain.Common;

namespace VatCalculator.App.Controllers
{
    [Route("api/vat-calculations")]
    public class VatCalculationsController: ApiController
    {
        private readonly ILogger<VatCalculationsController> _logger;
        private readonly IGetCalculationRequestFactory _factory;

        public VatCalculationsController(ILogger<VatCalculationsController> logger
            , IGetCalculationRequestFactory factory)
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-Us");
            _logger = logger;
            _factory = factory;
        }

        [HttpGet()]
        public async Task<IActionResult> Get(
                [FromQuery] GetVatCalculationInput input
                , CancellationToken cancellationToken)
        {
            var getVatCalculationRequest = _factory.GetInstance(input);
            getVatCalculationRequest.Vat = input.Vat;
            getVatCalculationRequest.PriceWithoutVat = input.PriceWithoutVat;
            getVatCalculationRequest.PriceWithVat = input.PriceWithVat;
            getVatCalculationRequest.VatRate = input.VatRate;

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