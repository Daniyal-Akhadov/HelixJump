using CodeBase.Logic.Player;
using UnityEngine;

namespace CodeBase.Logic.Tower
{
    public sealed class Spike : MonoBehaviour
    {
        [SerializeField] private int _damage = 1;

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.TryGetComponent(out BallHealth health))
            {
                health.TakeDamage(_damage);
            }
        }
    }
}