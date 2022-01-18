namespace Domain;
public class Entity
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public DateTime Created_Date { get; set; } = DateTime.Now;

}

