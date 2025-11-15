namespace StockNewsTracker.Server.Model.Request
{
    public class DeleteCompaniesRequest
    {
        public ICollection<string> Companies { get; set; }
    }
}