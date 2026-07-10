namespace OpenRhythm.Common;

public interface IBeatmapDecoder<out T> : IDisposable where T : IBeatmap
{
    T Decode(byte[] data);
}