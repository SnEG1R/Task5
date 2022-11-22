using Bogus;
using MediatR;
using Task5.Application.Common.Constants;
using Task5.Application.Common.Generators;
using Task5.Application.Common.Generators.Interfaces;
using Task5.Application.Interfaces;

namespace Task5.Application.CQs.User.Queries.GetListPersonData;

public class GetListPersonDataQueryHandler :
    IRequestHandler<GetListPersonDataQuery, GetListPersonDataVm>
{
    private Faker _faker = null!;
    private IPersonDataGenerator _personDataGenerator = null!;
    private IErrorGenerator _errorGenerator = null!;
    private readonly IApplicationVillageDbContext _villageDbContext;

    public GetListPersonDataQueryHandler(IApplicationVillageDbContext villageDbContext)
    {
        _villageDbContext = villageDbContext;
    }

    public async Task<GetListPersonDataVm> Handle(GetListPersonDataQuery request,
        CancellationToken cancellationToken)
    {
        var listPerson = new List<PersonDto>();
        _faker = new Faker(request.Region);

        for (var seed = request.Seed; seed < request.Seed + request.CountLoadRecord; seed++)
        {
            listPerson.Add(await CreateUser(seed, request.ErrorValue));
        }

        return new GetListPersonDataVm() { PersonDataDtos = listPerson };
    }

    private Task<PersonDto> CreateUser(int seed, double errorValue)
    {
        _faker.Random = new Randomizer(seed);
        _personDataGenerator = new PersonDataGenerator(_villageDbContext, _faker.Locale, seed);
        _errorGenerator = new ErrorGenerator(_faker.Locale, seed, errorValue);

        var fullName = _personDataGenerator.GenerateFullName();
        var address = _personDataGenerator.GenerateAddress();
        var phoneNumber = _personDataGenerator.GeneratePhoneNumber();

        var lines = _errorGenerator
            .GenerateError(fullName, address, phoneNumber);

        var person = new PersonDto()
        {
            FullName = lines.Item1,
            Address = lines.Item2,
            PhoneNumber = lines.Item3
        };

        return Task.FromResult(person);
    }
}