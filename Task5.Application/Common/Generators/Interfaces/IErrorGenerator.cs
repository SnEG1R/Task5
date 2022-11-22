namespace Task5.Application.Common.Generators.Interfaces;

public interface IErrorGenerator
{
    (string, string, string) GenerateError(params string[] lines);
}