namespace Task5.Domain;

public class Address
{
    public long Id { get; set; }
    public City City { get; set; }
    public Street Street { get; set; }
    public Building Building { get; set; }
    public Apartment Apartment { get; set; }
    public State State { get; set; }
}

public class City : BaseEntity
{
}

public class Street : BaseEntity
{
}

public class Building : BaseEntity
{
}

public class Apartment : BaseEntity
{
}

public class State : BaseEntity
{
}