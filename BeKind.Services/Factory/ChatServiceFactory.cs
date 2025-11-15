using StockNewsTracker.Services.Intrerface;
using StockNewsTracker.Services.Intrerface.Factory;
using StockNewsTracker.Services.Services;

namespace StockNewsTracker.Services.Factory
{
    public class ChatServiceFactory : IChatServiceFactory
    {
        private readonly string _apiKey;

        public ChatServiceFactory(string apiKey)
        {
            _apiKey = apiKey;
        }

        public IChatService Create(string model)
        {
            return new ChatService(_apiKey, model);
        }
    }
}
