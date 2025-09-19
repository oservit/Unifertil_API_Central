using Application.Services.Sync;
using Libs.Common;
using Microsoft.AspNetCore.Mvc;

namespace API.Central.Controllers
{
    [ApiController]
    [Route("api/Test/SyncScheduled")]
    public class SyncScheduledTestController : ControllerBase
    {
        private readonly ISyncScheduledAppService _scheduledService;

        public SyncScheduledTestController(ISyncScheduledAppService scheduledService)
        {
            _scheduledService = scheduledService;
        }

        /// <summary>
        /// Executa o processamento de agendamentos pendentes
        /// </summary>
        [HttpPost("Run")]
        public async Task<ActionResult<DataResult>> Run()
        {
            try
            {
                await _scheduledService.ProcessScheduledAsync();

                return Ok(new DataResult
                {
                    Success = true,
                    Message = "Processamento de agendamentos concluído com sucesso"
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new DataResult
                {
                    Success = false,
                    Message = $"Erro ao processar agendamentos: {ex.Message}"
                });
            }
        }
    }
}
