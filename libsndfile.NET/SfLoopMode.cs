using JetBrains.Annotations;

namespace libsndfile.NET
{
    [PublicAPI]
    public enum SfLoopMode
    {
        None = 800,
        Forward,
        Backward,
        Alternating
    }
}