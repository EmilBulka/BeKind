using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockNewsTracker.Services.Intrerface.Factory
{
    public interface IChatServiceFactory
    {
        /// <summary>
        /// Tworzy instancję ChatService dla podanego modelu.
        /// </summary>
        /// <param name="model">Nazwa modelu, np. "gpt-3.5-turbo"</param>
        /// <returns>IChatService</returns>
        IChatService Create(string model);
    }
}
