namespace Felipe.Application.DTOs
{
    public class ChecklistItemDTO
    {
        public int? Id { get; set; }
        public string? Name { get; set; }
        public string? Observation { get; set; }
        public bool IsApproved { get; set; }
    }
}
