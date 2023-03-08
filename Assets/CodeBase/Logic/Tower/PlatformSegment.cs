using UnityEngine;

namespace CodeBase.Logic.Tower
{
    [RequireComponent(typeof(Rigidbody))]
    public class PlatformSegment : MonoBehaviour
    {
        private ISegmentBehaviour _segmentBehaviour;

        public void SetBreakBehaviour(ISegmentBehaviour segmentBehaviour)
        {
            _segmentBehaviour = segmentBehaviour;
        }

        public void Perform()
        {
            _segmentBehaviour.Execute();
        }
    }
}