using UnityEngine;

namespace CodeBase.Logic.Tower
{
    public class ExplosionBreakBehaviour : IBreakBehaviour
    {
        private readonly Rigidbody _rigidbody;
        private readonly float _force;
        private readonly Vector3 _center;
        private readonly float _radius;

        public ExplosionBreakBehaviour(GameObject gameObject)
        {
            _rigidbody = gameObject.GetComponent<Rigidbody>();
            _force = 500f;
            _center = gameObject.transform.position;
            _radius = 100f;
        }

        public void Execute()
        {
            Explode();
        }

        private void Explode()
        {
            _rigidbody.transform.SetParent(null);
            _rigidbody.isKinematic = false;
            _rigidbody.AddExplosionForce(_force, _center, _radius);
        }
    }
}