using CodeBase.Logic.Tower;
using UnityEngine;

namespace CodeBase.Logic.Platform
{
    public class StartPlatform : BasePlatform
    {
        [SerializeField] private Transform _spawnPoint;

        public Transform SpawnPoint => _spawnPoint;

        protected override void SetupSegments()
        {
            foreach (PlatformSegment segment in Segments)
            {
                segment.SetBreakBehaviour(new ExplosionBreakBehaviour(segment.gameObject));
            }
        }
    }
}