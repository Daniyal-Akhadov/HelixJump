using CodeBase.Logic.Platform;
using CodeBase.Logic.Player;
using UnityEngine;

namespace CodeBase.UI
{
    public class ActorUI : MonoBehaviour
    {
        [SerializeField] private LevelBar _levelBar;

        private BallPlatformBreaker _ball;
        private FinishBasePlatform _finishPlatform;

        private void Start()
        {
            _ball = FindObjectOfType<BallPlatformBreaker>();
            _finishPlatform = FindObjectOfType<FinishBasePlatform>();

            _ball.OnBroken += OnPlatformBroken;
        }

        private void OnPlatformBroken(int number)
        {
            _levelBar.SetValue(number, 100);
        }
    }
}