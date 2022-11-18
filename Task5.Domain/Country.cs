namespace Task5.Domain;

public class Country
{
    public long Id { get; set; }
    public string Value { get; set; }
    
    public List<FirstName> FirstNames { get; set; }
    public List<LastName> LastNames { get; set; }
    public List<Address> Addresses { get; set; }
    public List<NumberPhone> NumberPhones { get; set; }
}