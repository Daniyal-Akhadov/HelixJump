using CodeBase.Logic.Platform;
using CodeBase.Logic.Player;
using CodeBase.Logic.Tower;
using UnityEngine;

namespace CodeBase.UI.Elements
{
    public class ActorUI : MonoBehaviour
    {
        [SerializeField] private LevelBar _levelBar;

        private BallPlatformBreaker _ball;
        private FinishBasePlatform _finishPlatform;
        private TowerBuilder _towerBuilder;

        public void Construct(BallPlatformBreaker ballPlatformBreaker, TowerBuilder towerBuilder)
        {
            _ball = ballPlatformBreaker;
            _towerBuilder = towerBuilder;
            _ball.OnBroken += OnPlatformBroken;
        }

        private void OnDisable()
        {
            _ball.OnBroken -= OnPlatformBroken;
        }

        private void OnPlatformBroken(int number)
        {
            _levelBar.SetValue(number, _towerBuilder.LevelCount);
        }
    }
}