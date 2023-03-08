using CodeBase.Infrastructure.Services;
using UnityEngine;

namespace CodeBase.Logic.Player
{
    public class BallDeath : MonoBehaviour
    {
        public bool IsDied { get; private set; }

        private IInputService _inputService;

        public void Construct(IInputService inputService)
        {
            _inputService = inputService;
        }

        public void Die()
        {
            _inputService.Block();
            IsDied = true;
            gameObject.SetActive(false);
        }
    }
}