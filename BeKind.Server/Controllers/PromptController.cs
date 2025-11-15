using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OpenAI.Chat;
using StockNewsTracker.Server.Model.Request;
using StockNewsTracker.Services.Intrerface;
using StockNewsTracker.Services.Intrerface.Factory;

namespace StockNewsTracker.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PromptController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly IChatServiceFactory _chatFactory;

        public PromptController(IConfiguration config, IChatServiceFactory chatFactory)
        {
            _config = config;
            _chatFactory = chatFactory;
        }

        [HttpPost("ask")]
        public async Task<IActionResult> Ask([FromBody] ChatRequest request)
        {
            var modelToUse = string.IsNullOrWhiteSpace(request.Model) ? "gpt-3.5-turbo" : request.Model;

            var chatService = _chatFactory.Create(modelToUse);
            var response = await chatService.AskAsync(request.Prompt);

            return Ok(new { model = modelToUse, prompt = request.Prompt, response });
        }
    }
}
