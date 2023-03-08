using UnityEngine;

namespace CodeBase.Logic.Player
{
    public class BallHealth : MonoBehaviour
    {
        [SerializeField] private int _health = 10;

        private BallDeath _death;

        private void Awake()
        {
            _death = GetComponent<BallDeath>();
        }

        public void TakeDamage(int damage)
        {
            _health -= damage;
            Debug.Log($"TakeDamage; Current health: {_health}");
            if (_health <= 0 && _death.IsDied == false)
            {
                _death.Die();
            }
        }
    }
}