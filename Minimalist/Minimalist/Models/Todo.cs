using System.ComponentModel.DataAnnotations;

namespace Minimalist.Models;

public class Todo
{
    [Key] [Required] public int Id { get; set; }

    [Required(ErrorMessage = "Title is required")]
    public string Title { get; set; }
}