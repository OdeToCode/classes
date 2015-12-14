using System.ComponentModel.DataAnnotations;

namespace Flow.Models
{
    public class Guest
    {
        [Required]
        public string Name { get; set; }
        public string Message { get; set; }
    }
}