namespace BeKind.Infrastructure.Entities
{
    public class CompanyDSO
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public ICollection<MemberCompanyDSO> MemberCompanies { get; set; }
        public bool IsNotifyActive { get; set; }
    }
}
