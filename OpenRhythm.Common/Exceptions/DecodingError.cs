// Copyright (c) 2026 SynesthesiaDev <synesthesiadev@proton.me>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

namespace OpenRhythm.Common.Exceptions;

public class DecodingError(string message) : Exception
{
    public static void Assert(bool condition, string message)
    {
        if(!condition) Throw(message);
    }

    public static void Throw(string message) => throw new DecodingError(message);

    public override string Message => message;
}
