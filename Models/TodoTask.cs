using System.ComponentModel.DataAnnotations;

namespace ToDo.Models
{
    public class TodoTask
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(30)]
        public string? Title { get; set; }

        [Required]
        [StringLength(300)]
        public string? Description { get; set; } = string.Empty;

        [Required]
        public bool Finished { get; set; }
    }
}
