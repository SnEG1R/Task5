namespace Task5.Domain;

public class Country
{
    public long Id { get; set; }
    public string Name { get; set; }
    
    public virtual List<Village> Villages { get; set; }
}