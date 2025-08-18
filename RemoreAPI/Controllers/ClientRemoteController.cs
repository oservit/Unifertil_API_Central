using Application.Remote.Services;
using Application.Remote.Services.Clients;
using Microsoft.AspNetCore.Mvc;

namespace API.Remote.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientRemoteController : ControllerBase
    {
        private readonly IClientRemoteAppService _clientService;

        public ClientRemoteController(IClientRemoteAppService clientService)
        {
            _clientService = clientService;
        }

        [HttpGet("ListAll")]
        public async Task<IActionResult> ListAll()
        {
            var token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6ImFkbWluIiwibmFtZWlkIjoiMSIsIm5iZiI6MTc1NTI2NDY4NiwiZXhwIjoxNzU1MzUxMDg2LCJpYXQiOjE3NTUyNjQ2ODYsImlzcyI6IkRhdGFBY2Vzc0FQSSIsImF1ZCI6IkRhdGFBY2Vzc0FQSUNvbnN1bWVycyJ9.elW-ItkBKShBI1nUkmUq9lxMVEVoSVZasN6D0Jlge-c";
            var clients = await _clientService.ListAllAsync(token);
            return Ok(clients);
        }

        [HttpGet("{id:long}")]
        public async Task<IActionResult> GetById(long id)
        {
            var token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6ImFkbWluIiwibmFtZWlkIjoiMSIsIm5iZiI6MTc1NTI2NDY4NiwiZXhwIjoxNzU1MzUxMDg2LCJpYXQiOjE3NTUyNjQ2ODYsImlzcyI6IkRhdGFBY2Vzc0FQSSIsImF1ZCI6IkRhdGFBY2Vzc0FQSUNvbnN1bWVycyJ9.elW-ItkBKShBI1nUkmUq9lxMVEVoSVZasN6D0Jlge-c";
            var client = await _clientService.GetByIdAsync(id, token);
            if (client == null)
                return NotFound();

            return Ok(client);
        }
    }
}
