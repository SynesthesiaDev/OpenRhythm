namespace OpenRhythm.Common.Extensions;

public static class StreamExtensions
{
    extension(Stream stream)
    {
        public byte[] ToByteArray()
        {
            byte[] data;

            if (stream is MemoryStream ms)
            {
                data = ms.ToArray();
            }
            else
            {
                using var memoryStream = new MemoryStream();
                stream.CopyTo(memoryStream);
                data = memoryStream.ToArray();
            }

            return data;
        }
    }
}