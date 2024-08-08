namespace Felipe.Domain.Models
{
    public class Checklist : Base
    {
        public DateTime Date { get; set; }
        public ICollection<ChecklistItem> Items { get; set; }
        public bool IsApprovedBySupervisor { get; set; } = false;
        public int? ExecutorId { get; set; }
    }
}
