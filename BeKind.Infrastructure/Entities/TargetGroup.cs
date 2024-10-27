namespace BeKind.Infrastructure.Entities
{
    public class TargetGroup
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public List<Assignment> Assignments { get; set; }
    }
}
