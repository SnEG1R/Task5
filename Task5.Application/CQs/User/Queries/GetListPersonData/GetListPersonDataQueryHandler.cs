using Bogus;
using MediatR;
using Task5.Application.Common.Generators;
using Task5.Application.Common.Generators.Interfaces;
using Task5.Application.Interfaces;

namespace Task5.Application.CQs.User.Queries.GetListPersonData;

public class GetListPersonDataQueryHandler :
    IRequestHandler<GetListPersonDataQuery, GetListPersonDataVm>
{
    private Faker _faker = null!;
    private IPersonDataGenerator _personDataGenerator = null!;
    private IApplicationVillageDbContext _villageDbContext;

    public GetListPersonDataQueryHandler(IApplicationVillageDbContext villageDbContext)
    {
        _villageDbContext = villageDbContext;
    }

    public async Task<GetListPersonDataVm> Handle(GetListPersonDataQuery request,
        CancellationToken cancellationToken)
    {
        var listPerson = new List<PersonDto>();
        _faker = new Faker(request.Region);

        for (var seed = request.Seed; seed < request.Seed + 20; seed++)
        {
            listPerson.Add(await CreateUser(seed));
        }

        return new GetListPersonDataVm() { PersonDataDtos = listPerson };
    }

    private Task<PersonDto> CreateUser(int seed)
    {
        _faker.Random = new Randomizer(seed);
        _personDataGenerator = new PersonDataGenerator(_villageDbContext, _faker.Locale, seed);
        
        var firstName = _personDataGenerator.GenerateFullName();
        var address = _personDataGenerator.GenerateAddress();
        
        var phoneNumber = _faker.Phone.PhoneNumber();

        var person = new PersonDto()
        {
            FullName = $"{firstName}",
            PhoneNumber = phoneNumber,
            Address = address
        };

        return Task.FromResult(person);
    }
}