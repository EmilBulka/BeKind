using System.ComponentModel.DataAnnotations;

namespace BeKind.Infrastructure.Entities.ManyToManyRelationObjects
{
    public class AssignmentTargetGroups
    {
        public Assignment Assignment { get; set; }
        public int AssignmentId { get; set; }
        public int TargetGroupId { get; set; }
        
        public TargetGroup TargetGroup { get; set; }
    }
}
