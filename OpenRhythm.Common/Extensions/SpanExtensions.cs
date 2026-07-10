// Copyright (c) 2026 SynesthesiaDev <synesthesiadev@proton.me>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using System.Drawing;
using System.Text;
using OpenRhythm.Common.Exceptions;
using Synesthesia.Utils.Extensions;

namespace OpenRhythm.Common.Extensions;

public static class SpanExtensions
{
    public static string ToListString<T>(this ICollection<T> collection)
    {
        var builder = new StringBuilder();
        builder.Append("[");
        foreach (var (index, item) in collection.Index())
        {
            builder.Append($"{item}");
            if (index != collection.Count - 1) builder.Append(", ");
        }

        return builder.Append("]").ToString();
    }

    public static Color ToColor(this string[] collection)
    {
        DecodingError.Assert(collection.Length == 3, "Colors are defined in triples of integers (int r, int g, int b)");
        return Color.FromArgb(255, collection[0].ToInt().Clamp(0, 255), collection[1].ToInt().Clamp(0, 255), collection[2].ToInt().Clamp(0, 255));
    }
}
