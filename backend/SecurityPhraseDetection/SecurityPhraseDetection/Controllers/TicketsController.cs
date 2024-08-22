using Microsoft.AspNetCore.Mvc;
using SecurityPhraseDetection.Services;

namespace SecurityPhraseDetection.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TicketsController : ControllerBase
    {
        private readonly ITicketService _ticketService;

        public TicketsController(ITicketService ticketService)
        {
            _ticketService = ticketService;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsersWithConversations()
        {
            var users = await _ticketService.GetProcessedUsersWithConversationsAsync();
            return Ok(users);
        }
    }
}
