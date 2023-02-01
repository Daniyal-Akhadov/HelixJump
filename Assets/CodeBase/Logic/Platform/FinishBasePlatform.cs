using CodeBase.Logic.Tower;

namespace CodeBase.Logic.Platform
{
    public class FinishBasePlatform : BasePlatform
    {
        protected override void SetupSegments()
        {
            foreach (PlatformSegment segment in Segments)
            {
                segment.SetBreakBehaviour(new NoBreakBehaviour());
            }
        }
    }
}