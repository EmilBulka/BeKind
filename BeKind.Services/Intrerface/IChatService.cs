namespace StockNewsTracker.Services.Intrerface
{
    public interface IChatService
    {
        /// <summary>
        /// Wysyła prompt do ChatGPT i zwraca odpowiedź.
        /// </summary>
        /// <param name="prompt">Tekst promptu</param>
        /// <returns>Odpowiedź od modelu</returns>
        Task<string> AskAsync(string prompt);
    }
}