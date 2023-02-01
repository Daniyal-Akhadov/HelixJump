using CodeBase.Logic.Tower;
using UnityEngine;

namespace CodeBase.Logic.Player
{
    [RequireComponent(typeof(Rigidbody))]
    public class BallJumper : MonoBehaviour
    {
        [SerializeField] private float _force = 10f;
        [SerializeField] private GameObject _splash;

        private Rigidbody _rigidbody;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.TryGetComponent(out PlatformSegment _))
            {
                Vector3 position = collision.GetContact(0).point + Vector3.up * 0.03f;
                GameObject newSplash = Instantiate(_splash, position, transform.rotation);
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

    public class Ball : MonoBehaviour
    {
        
    }
}