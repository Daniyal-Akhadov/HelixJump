using CodeBase.Logic.Player;
using CodeBase.Logic.Tower;
using UnityEngine;
using UnityEngine.Serialization;

namespace CodeBase.Logic.Platform
{
    public class StartPlatform : BasePlatform
    {
        [FormerlySerializedAs("ballPlatformBreaker")] [SerializeField]
        private BallPlatformBreaker _ball;

        [SerializeField] private Transform _spawnPoint;

        protected override void Awake()
        {
            base.Awake();
            Instantiate(_ball, _spawnPoint.position, _ball.transform.rotation);
        }

        protected override void SetupSegments()
        {
            foreach (PlatformSegment segment in Segments)
            {
                segment.SetBreakBehaviour(new ExplosionBreakBehaviour(segment.gameObject));
            }
        }
    }
}