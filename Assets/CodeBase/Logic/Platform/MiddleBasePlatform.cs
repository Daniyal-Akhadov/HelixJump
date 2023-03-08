using CodeBase.Logic.Tower;

namespace CodeBase.Logic.Platform
{
    public class MiddleBasePlatform : BasePlatform
    {
        protected override void SetupSegments()
        {
            foreach (PlatformSegment segment in Segments)
            {
                segment.SetBreakBehaviour(new ExplosionSegmentBehaviour(segment.gameObject));
            }
        }
    }
}