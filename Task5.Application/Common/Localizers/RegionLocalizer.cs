using System.Globalization;
using Task5.Application.Common.Constants;

namespace Task5.Application.Common.Localizers;

public static class RegionLocalizer
{
    public static readonly Dictionary<string, string> Houses
        = new()
        {
            { "en", "Hse." },
            { "uk", "буд." },
            { "pl", "ul." }
        };

    public static readonly Dictionary<string, string> PhoneCode
        = new()
        {
            { "en", "+44" },
            { "uk", "+380" },
            { "pl", "+48" }
        };

    public static readonly Dictionary<string, string> Cities
        = new()
        {
            { "en", "cit." },
            { "uk", "м." },
            { "pl", "m." }
        };

    public static readonly Dictionary<string, string> Villages =
        new()
        {
            { "en", "vil." },
            { "uk", "д." },
            { "pl", "w." }
        };
}