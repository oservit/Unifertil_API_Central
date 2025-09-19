using Application.Common.Sync;
using Application.Features.Products;
using Application.Features.Sync.Products;
using Infrastructure.Http;
using Libs.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Central.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/Product/Sync")]
    public class ProductSyncController : ControllerBase
    {
        private readonly IProductSyncAppService _appService;

        public ProductSyncController(
            IProductSyncAppService appService)
        {
            _appService = appService;
        }

        /// <summary>
        /// Recebe um produto para sincronizar localmente
        /// </summary>
        [HttpPost("Receive")]
        public async Task<ActionResult<ApiResponse<DataResult>>> Receive([FromBody] SyncMessage<ProductViewModel> message)
        {
            var result = await _appService.SyncLocal(message);

            if (result.Success)
                return Ok(result);

            return StatusCode(StatusCodes.Status500InternalServerError, result);
        }
    }
}
