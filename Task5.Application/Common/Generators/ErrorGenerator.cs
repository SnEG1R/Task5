using System.Text;
using Task5.Application.Common.Constants;
using Task5.Application.Common.Generators.Interfaces;

namespace Task5.Application.Common.Generators;

public class ErrorGenerator : IErrorGenerator
{
    private readonly double _errorValue;
    private readonly string _region;
    private readonly Random _random;

    public ErrorGenerator(string region, int seed, double errorValue)
    {
        _errorValue = errorValue;
        _region = region;
        _random = new Random(seed);
    }

    public string[] GenerateError(params string[] lines)
    {
        var (countError, probability) = GetCountErrorAndProbability();
        int changeLineIndex;

        for (var i = 0; i < countError; i++)
        {
            changeLineIndex = _random.Next(0, lines.Length);

            var operation = GetRandomOperation();
            lines[changeLineIndex] = operation(lines[changeLineIndex]);
        }

        if (_random.Next(1, 101) < probability * 100)
        {
            changeLineIndex = _random.Next(0, lines.Length);

            var operation = GetRandomOperation();
            lines[changeLineIndex] = operation(lines[changeLineIndex]);
        }

        return lines;
    }

    private string RemoveRandomChar(string line)
    {
        if (line.Length <= 15)
            return line;

        var position = _random.Next(line.Length);

        line = line.Remove(position, 1);

        return line;
    }

    private string InsertRandomCharToLine(string line)
    {
        if (line.Length <= 15)
            return line;

        var insertPosition = _random.Next(line.Length);

        var pickList = _random.Next(1, 3) == 1
            ? GetAlphabetRegion(_region)
            : Numbers.Values;

        var positionChar = _random.Next(pickList.Length);
        var charValue = pickList[positionChar];

        line = line.Insert(insertPosition, charValue.ToString());

        return line;
    }

    private string RearrangingRandomTwoChars(string line)
    {
        var stringBuilder = new StringBuilder(line);

        if (stringBuilder.Length <= 3)
            return line;

        var charPosition = _random.Next(stringBuilder.Length - 2);
        var firstChar = stringBuilder[charPosition];
        var secondChar = stringBuilder[charPosition + 1];

        stringBuilder[charPosition] = secondChar;
        stringBuilder[charPosition + 1] = firstChar;

        return stringBuilder.ToString();
    }

    private (int, int) GetCountErrorAndProbability()
    {
        var countErrorAndProbability = _errorValue.ToString().Split('.', ',');
        var probability = 0;

        var countError = Convert.ToInt32(countErrorAndProbability[0]);

        if (countErrorAndProbability.Length > 1)
        {
            probability = Convert.ToInt32(countErrorAndProbability[1]);
        }

        return new ValueTuple<int, int>(countError, probability);
    }

    private string GetAlphabetRegion(string region)
    {
        return region switch
        {
            Regions.En => Alphabets.English,
            Regions.Uk => Alphabets.Ukraine,
            Regions.Pl => Alphabets.Poland,
            _ => throw new ArgumentOutOfRangeException(nameof(region), region, null)
        };
    }

    private Func<string, string> GetRandomOperation()
    {
        var randomValue = _random.NextDouble() * 100;

        return randomValue switch
        {
            > 0 and <= 33.333 => RemoveRandomChar,
            > 33.333 and <= 66.666 => RearrangingRandomTwoChars,
            > 66.666 and <= 100 => InsertRandomCharToLine,
            _ => throw new ArgumentOutOfRangeException()
        };
    }
}