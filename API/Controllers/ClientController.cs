using Application.Features.Clients;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Central.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class ClientController : ControllerBase
    {
        private readonly IClientAppService _appService;
        private readonly IMapper _mapper;

        public ClientController(IClientAppService appService, IMapper mapper)
        {
            _appService = appService;
            _mapper = mapper;
        }

        [HttpGet("ListAll")]
        public async Task<IActionResult> ListAll()
        {
            var clients = await _appService.GetListPaged();
            return Ok(clients);
        }

        [HttpGet("{id:long}")]
        public async Task<IActionResult> GetById(long id)
        {
            var client = await _appService.Get(id);
            if (client == null)
                return NotFound();

            return Ok(client);
        }

        [HttpPost("Save")]
        public async Task<IActionResult> Create([FromBody] CreateClientModel model)
        {
            var result = await this._appService.Save(model);

            if (result.Success)
                return Ok(result);
            else
                return StatusCode(StatusCodes.Status500InternalServerError, result);
        }

        [HttpPut("Update/{id}")]
        public async Task<IActionResult> Update([FromRoute] long id, [FromBody] UpdateClientModel updateModel)
        {

            var result = await this._appService.Update(id, updateModel);

            if (result.Success)
                return Ok(result);
            else
                return StatusCode(StatusCodes.Status500InternalServerError, result);
        }
    }
}
