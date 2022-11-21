using Task5.Domain;

namespace Task5.Application.Common.Generators.Interfaces;

public interface IPersonDataGenerator
{
    string GenerateFullName();
    string GenerateAddress();
}