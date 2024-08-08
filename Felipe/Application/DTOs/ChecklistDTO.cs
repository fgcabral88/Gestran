using Felipe.Domain.Models;

namespace Felipe.Application.DTOs
{
    public class ChecklistDTO
    {
        public int? Id { get; set; }
        public DateTime Date { get; set; }
        public ICollection<ChecklistItem>? Items { get; set; }
        public bool IsApprovedBySupervisor { get; set; }
    }
}
