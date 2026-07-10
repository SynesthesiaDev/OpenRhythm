using OpenRhythm.Common;

namespace OpenRhythm.Osu;

public class OsuBeatmapDecoder : IBeatmapDecoder<OsuBeatmap>
{
    public OsuBeatmap Decode(byte[] data)
    {
        return new OsuBeatmap();
    }

    public void Dispose()
    {
        
    }
}