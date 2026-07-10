// Copyright (c) 2026 SynesthesiaDev <synesthesiadev@proton.me>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

namespace OpenRhythm.Common.Extensions;

public static class NumberExtensions
{
    public static double Clamp(this double num, double min, double max) => Math.Clamp(num, min, max);
    public static int Clamp(this int num, int min, int max) => Math.Clamp(num, min, max);

}
