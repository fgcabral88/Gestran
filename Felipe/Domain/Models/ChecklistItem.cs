namespace Felipe.Domain.Models
{
    public class ChecklistItem : Base
    {
        public string? Name { get; set; }
        public string? Observation { get; set; }
        public bool IsApproved { get; set; } = false;
    }
}
