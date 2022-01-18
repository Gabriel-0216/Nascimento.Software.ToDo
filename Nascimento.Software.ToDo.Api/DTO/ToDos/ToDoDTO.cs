namespace Nascimento.Software.ToDo.Api.DTO.ToDos
{
    public class ToDoDTO
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public bool IsCompleted { get; set; }
        public Guid UserId { get; set; } = Guid.Empty;
        public Guid CategoryId { get; set; } = Guid.Empty;

    }
}
