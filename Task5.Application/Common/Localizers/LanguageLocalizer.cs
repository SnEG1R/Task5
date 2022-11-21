using System.Globalization;
using Task5.Application.Common.Constants;

namespace Task5.Application.Common.Localizers;

public static class LanguageLocalizer
{
    public static readonly Dictionary<string, string> Houses
        = new()
        {
            { "en", "Hse." },
            { "uk", "д." },
            { "pl", "ul." }
        };

    public static readonly Dictionary<string, string> PhoneCode
        = new()
        {
            { "en", "+44" },
            { "uk", "+380" },
            { "pl", "+48" }
        };
}