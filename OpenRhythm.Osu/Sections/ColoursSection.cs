// Copyright (c) 2026 SynesthesiaDev <synesthesiadev@proton.me>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using System.Drawing;
using OpenRhythm.Common.Extensions;

namespace OpenRhythm.Osu.Sections;

/// <param name="ComboColors">Additive combo colours</param>
/// <param name="SliderTrackOverride">Additive slider track colour</param>
/// <param name="SliderBorder">Slider border colour</param>
public record ColoursSection(
    List<Color> ComboColors,
    Color? SliderTrackOverride,
    Color? SliderBorder)
{
    public static ColoursSection Parse(string sectionText)
    {
        var colors = new List<Color>();
        var parser = new OsuSection(sectionText);

        var count = parser.KeyValuePairs.Keys.Count(key => key.StartsWith("Combo"));
        for (int i = 1; i < count; i++)
        {
            var comboColor = parser.Get<Color>($"Combo{i}");
            colors.Add(comboColor);
        }

        return new ColoursSection
        (
            colors,
            parser.GetOrNull<Color>("SliderTrackOverride"),
            parser.GetOrNull<Color>("SliderBorder")
        );
    }

    public override string ToString() => $"{GetType().Name} {{ ComboColors = {ComboColors.ToListString()}, SliderTrackOverride = {SliderTrackOverride}, SliderBorder = {SliderTrackOverride} }}";
}
