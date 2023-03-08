using UnityEngine;

namespace CodeBase.Logic.Tower
{
    public class ExplosionSegmentBehaviour : ISegmentBehaviour
    {
        private readonly Rigidbody _rigidbody;
        private readonly float _force;
        private readonly Vector3 _center;
        private readonly float _radius;

        public ExplosionSegmentBehaviour(GameObject segment)
        {
            _rigidbody = segment.GetComponent<Rigidbody>();
            _center = segment.transform.position;
            _force = 500f;
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