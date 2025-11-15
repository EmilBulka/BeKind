using OpenAI.Chat;
using StockNewsTracker.Services.Intrerface;

namespace StockNewsTracker.Services.Services
{
    public class ChatService : IChatService
    {
        private readonly string _apiKey;
        private readonly string _model;

        public ChatService(string apiKey, string model)
        {
            _apiKey = apiKey;
            _model = model;
        }

        public async Task<string> AskAsync(string prompt)
        {
            var client = new ChatClient(model: _model, apiKey: _apiKey);
            var result = await client.CompleteChatAsync(prompt);
            return result.Value.Content[0].Text;
        }
    }
}
