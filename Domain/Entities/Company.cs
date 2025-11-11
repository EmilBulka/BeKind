namespace Domain.Entities
{
    public class Company
    {
        public Company(string name, bool isNotifyActive = false)
        {
            Name = name;
            IsNotifyActive = isNotifyActive;
        }
        public int RecordId { get; set; }
        public bool IsNotifyActive { get; set; }
        public string Name { get; set; }

    }
}