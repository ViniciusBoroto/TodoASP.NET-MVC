using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace ToDo.Models
{
    public class TodoTask
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [BindProperty]
        [StringLength(30)]
        public string? Title { get; set; }

        [Required]
        [BindProperty]
        [StringLength(300)]
        public string? Description { get; set; } = string.Empty;

        [Required]
        [BindProperty]
        public bool Finished { get; set; }
    }
}
