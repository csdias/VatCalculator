using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using VatCalculator.Application.Queries.GetVatCalculationQuery;
using VatCalculator.Domain.Common;
using MediatR;

namespace VatCalculator.App.Controllers
{
    [Route("api/vat-calculations")]
    public class VatCalculationsController: ApiController
    {
        private readonly ILogger<VatCalculationsController> _logger;

        public VatCalculationsController(ILogger<VatCalculationsController> logger)
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-Us");
            _logger = logger;
        }

        [HttpGet()]
        public async Task<IActionResult> Get(
                [FromQuery] GetVatCalculationRequest getVatCalculationRequest
                , CancellationToken cancellationToken)
        {
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