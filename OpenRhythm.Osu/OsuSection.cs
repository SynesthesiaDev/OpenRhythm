// Copyright (c) 2026 SynesthesiaDev <synesthesiadev@proton.me>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using System.Collections.Immutable;
using System.Drawing;
using OpenRhythm.Common.Exceptions;
using OpenRhythm.Common.Extensions;
using Synesthesia.Utils.Extensions;

namespace OpenRhythm.Osu;

public record OsuSection
{
    private readonly Dictionary<string, string> keyValuePairs = [];

    public IReadOnlyDictionary<string, string> KeyValuePairs => keyValuePairs.ToImmutableDictionary();

    public int Count => keyValuePairs.Count;

    public OsuSection(string sectionText)
    {
        var lines = sectionText.Split("\n").ToList();

        foreach (var line in lines.Select(l => l.Trim()).ToList())
        {
            if (line.StartsWith("[") && line.EndsWith("]") || !line.Contains(":"))
            {
                continue;
            }

            var split = line.Split(":");
            DecodingError.Assert(split.Length == 2, "Failed to parse key: value pair");

            var key = split[0].RemoveSuffix(" "); // colors are defined in "key : value" format
            var value = split[1].RemovePrefix(" "); // some are "key: value" and some are "key:value"

            keyValuePairs[key] = value;
        }
    }

    public T Get<T>(string key)
    {
        DecodingError.Assert(keyValuePairs.ContainsKey(key), $"Missing key '{key}'");
        return GetOrNull<T>(key) ?? throw new DecodingError($"Failed to decode key '{key}'");
    }

    public T? GetOrNull<T>(string key)
    {
        if (!keyValuePairs.TryGetValue(key, out var value))
        {
            return default;
        }

        return typeof(T) switch
        {
            var type when type == typeof(string) => (T)(object)value,

            var type when type == typeof(int) =>
                int.TryParse(value, out var i) ? (T)(object)i : default,

            var type when type == typeof(double) =>
                double.TryParse(value, out var d) ? (T)(object)d : default,

            var type when type == typeof(bool) =>
                (T)(object)(value == "1" || value.Equals("true", StringComparison.OrdinalIgnoreCase)),

            var type when type == typeof(string[]) =>
                (T)(object)value.Split(","),

            var type when type == typeof(int[]) =>
                (T)(object)value.Split(",").Select(s => s.ToInt()).ToArray(),

            var type when type == typeof(Color) =>
                (T)(object)value.Split(",").ToColor(),


            _ => default
        };
    }

    public T GetOrDefault<T>(string key, T value) => GetOrNull<T>(key) ?? value;
}
