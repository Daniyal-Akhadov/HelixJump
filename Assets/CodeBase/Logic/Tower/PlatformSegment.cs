using UnityEngine;

namespace CodeBase.Logic.Tower
{
    [RequireComponent(typeof(Rigidbody))]
    public class PlatformSegment : MonoBehaviour
    {
        private IBreakBehaviour _breakBehaviour;

        public void SetBreakBehaviour(IBreakBehaviour breakBehaviour)
        {
            _breakBehaviour = breakBehaviour;
        }

        public void PerformBreak()
        {
            _breakBehaviour.Execute();
        }
    }
}