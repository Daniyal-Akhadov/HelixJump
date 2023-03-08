using CodeBase.Logic.Tower;
using UnityEngine;

namespace CodeBase.Logic.Platform
{
    public abstract class BasePlatform : MonoBehaviour
    {
        protected PlatformSegment[] Segments;

        protected virtual void Awake()
        {
            Segments = GetComponentsInChildren<PlatformSegment>();
            SetupSegments();
        }

        public void Break()
        {
            foreach (PlatformSegment segment in Segments)
            {
                segment.Perform();
            }
        }

        protected abstract void SetupSegments();
    }
}