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

        private static Vector3 AdditiveHeightForSlash =>
            Vector3.up * 0.06f;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _splashPool = new MonoPoolService<Splash>(_splash, 10, transform, true);
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.TryGetComponent(out PlatformSegment _))
            {
                ContactPoint contact = collision.GetContact(0);
                Vector3 position = contact.point + AdditiveHeightForSlash;
                Quaternion rotation = Quaternion.LookRotation(Vector3.up);
                Splash newSplash = _splashPool.GetFreeElement(position, rotation);
                newSplash.transform.SetParent(collision.transform);
                Jump();
            }
        }

        private void Jump()
        {
            _rigidbody.velocity = Vector3.zero;
            _rigidbody.velocity = Vector3.up * _force;
        }
    }
}