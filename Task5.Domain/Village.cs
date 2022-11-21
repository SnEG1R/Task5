namespace Task5.Domain;

public class Village
{
    public long Id { get; set; }
    public string Name { get; set; }
    
    public virtual Country Country { get; set; }
}