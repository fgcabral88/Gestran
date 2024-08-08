using System.ComponentModel.DataAnnotations;

namespace Felipe.Domain.Models
{
    public class Base
    {
        [Key]
        public int? Id { get; set; }
    }
}
