using JetBrains.Annotations;

namespace libsndfile.NET
{
    [PublicAPI]
    public enum SfString
    {
        Title = 0x01,
        Copyright = 0x02,
        Software = 0x03,
        Artist = 0x04,
        Comment = 0x05,
        Date = 0x06,
        Album = 0x07,
        License = 0x08,
        TrackNumber = 0x09,
        Genre = 0x10
    }
}