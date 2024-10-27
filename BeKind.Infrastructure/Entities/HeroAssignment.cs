namespace BeKind.Infrastructure.Entities
{
    public class HeroAssignment : Assignment
    { 
        public DateTime StartTime  { get; set; }
        public DateTime EndTime { get; set; }
        public DateTime CompletedTime { get; set; }
        public int AssignmentStatusId { get; set; }
        public AssignmentStatus AssignmentStatus {  get; set; }
        public int MemberId { get; set; }
        public Member Member { get; set; }
        public int AssignmentId { get; set; }
    }
}
