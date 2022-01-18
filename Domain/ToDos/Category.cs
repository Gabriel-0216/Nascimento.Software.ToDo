using System.ComponentModel.DataAnnotations;

namespace Domain.ToDos;
public class Category : Entity
{
    [DataType(DataType.Text)]
    [Required]
    public string Name { get; set; } = string.Empty;
    [DataType(DataType.Text)]
    [Required]
    public string Description { get; set; } = string.Empty;
}