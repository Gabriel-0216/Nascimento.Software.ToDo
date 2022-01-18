using System.ComponentModel.DataAnnotations;
namespace Domain.ToDos;
public class ToDo : Entity
{
    [Required]
    public string Title { get; set; } = string.Empty;
    [Required]
    public string Description { get; set; } = string.Empty;
    [Required]
    public bool IsCompleted { get; set; }
    [Required]
    public Guid UserId { get; set; }
    public Users.User? User { get; set; }
    [Required]
    public Guid CategoryId { get; set; }
    public Category? Category { get; set; }

}

