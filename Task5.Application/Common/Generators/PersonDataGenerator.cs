using System.Text.RegularExpressions;
using Bogus;
using Task5.Application.Common.Constants;
using Task5.Application.Common.Generators.Interfaces;
using Task5.Application.Common.Localizers;
using Task5.Application.Interfaces;

namespace Task5.Application.Common.Generators;

public class PersonDataGenerator : IPersonDataGenerator
{
    private readonly IApplicationVillageDbContext _villageDbContext;
    private readonly Faker _faker;
    private readonly Random _random;
    private readonly int _seed;
    private readonly string _region;

    public PersonDataGenerator(IApplicationVillageDbContext villageDbContext,
        string region, int seed)
    {
        _faker = new Faker(region)
        {
            Random = new Randomizer(seed)
        };
        _random = new Random();
        _region = region;
        _seed = seed;
        _villageDbContext = villageDbContext;
    }

    public string GenerateFullName()
    {
        var secondName = "";

        if (_region == Regions.Uk)
            secondName = _faker.Name.FindName().Split()[1];

        var nameElements = _faker.Name.FullName().Split();

        var fullName = Regex.Replace($"{nameElements[0]} {secondName} " +
                                     $"{nameElements[1]}", @"\s+", " ");

        return fullName;
    }

    public string GenerateAddress()
    {
        string placeResidence;
        var street = _faker.Address.StreetName();
        var state = _faker.Address.State();
        var building = _faker.Address.BuildingNumber();
        var apartment = _faker.Address.SecondaryAddress();

        building = building
            .Insert(0, $"{LanguageLocalizer.Houses[_region]} ");

        if (_random.Next(1, 3) == 1)
        {
            placeResidence = _faker.Address.City();
        }
        else
        {
            var countVillage = _villageDbContext.Villages
                .Count(v => v.Country.Name == _region);
            placeResidence = _villageDbContext.Villages
                .Where(v => v.Country.Name == _region)
                .Select(v => v.Name)
                .ToList()
                .ElementAt(_random.Next(countVillage));
        }

        return string.IsNullOrWhiteSpace(state)
            ? $"{placeResidence}, {street}, {building}, {apartment}"
            : $"{placeResidence}, {state}, {street}, {building}, {apartment}";
    }
}