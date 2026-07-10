// Copyright (c) 2026 SynesthesiaDev <synesthesiadev@proton.me>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using OpenRhythm.Common.Extensions;

namespace OpenRhythm.Osu.Sections;

/// <param name="HpDrainRate">HP setting (0–10)</param>
/// <param name="CircleSize">CS setting (0–10)</param>
/// <param name="OverallDifficulty">OD setting (0–10)</param>
/// <param name="ApproachRate">AR setting (0–10)</param>
/// <param name="SliderMultiplier">Base slider velocity in hundreds of osu! pixels per beat</param>
/// <param name="SliderTickRate">Amount of slider ticks per beat</param>
public record DifficultySection(
    double HpDrainRate,
    double CircleSize,
    double OverallDifficulty,
    double ApproachRate,
    double SliderMultiplier,
    double SliderTickRate
)
{
    public static DifficultySection Parse(string sectionText)
    {
        var parser = new OsuSection(sectionText);
        return new DifficultySection
        (
            parser.Get<double>("HPDrainRate").Clamp(0, 10),
            parser.Get<double>("CircleSize").Clamp(0, 10),
            parser.Get<double>("OverallDifficulty").Clamp(0, 10),
            parser.Get<double>("ApproachRate").Clamp(0, 10),
            parser.Get<double>("SliderMultiplier"),
            parser.Get<double>("SliderTickRate")
        );
    }
}
