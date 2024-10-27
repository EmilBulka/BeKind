namespace BeKind.Infrastructure.Entities
{
    public class Assignment
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int DifficultyLevelId { get; set; }
        public DifficultyLevel DifficultyLevel { get; set; }
        public int TagretGroupId { get; set; }
        public List<TargetGroup> TargetGroups { get; set; }
    }
}
