namespace Task5.Application.Common.Generators.Interfaces;

public interface IErrorGenerator
{
    string[] GenerateError(params string[] lines);
}