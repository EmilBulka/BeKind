namespace BeKind.Infrastructure.Entities
{
    public class MemberCompanyDSO
    {
        public int Id { get; set; } 
        public int MemberId { get; set; }
        public MemberDSO Member { get; set; }
        public int CompanyId { get; set; }
        public CompanyDSO Company { get; set; }
        public bool IsNotifyActive { get; set; }
    }
}
