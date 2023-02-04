using CodeBase.Logic.Tower;
using Resources.GameLogic.Utility;
using UnityEngine;

namespace CodeBase.Logic.Player
{
    [RequireComponent(typeof(Rigidbody))]
    public class BallJumper : MonoBehaviour
    {
        [SerializeField] private float _force = 10f;
        [SerializeField] private Splash _splash;

        private Rigidbody _rigidbody;
        private MonoPoolService<Splash> _splashPool;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _splashPool = new MonoPoolService<Splash>(_splash, 10, transform, true);
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.TryGetComponent(out PlatformSegment _))
            {
                Vector3 position = collision.GetContact(0).point + Vector3.up * 0.03f;
                Splash newSplash = _splashPool.GetFreeElement(position, transform.rotation);
                newSplash.transform.SetParent(collision.transform);
                Jump();
            }
        }

        // public void SetSplash(Splash splash) =>
        //     _splash = splash;

        private void Jump()
        {
            _rigidbody.velocity = Vector3.zero;
            _rigidbody.velocity = Vector3.up * _force;
        }
    }
}