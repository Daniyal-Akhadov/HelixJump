using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BallJumper : MonoBehaviour
{
    [SerializeField] private float _jumpForce = 5f;

    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        var segment = collision.gameObject.GetComponent<PlatformSegment>();

        if (segment != null)
        {
            _rigidbody.velocity = Vector3.zero;
            _rigidbody.AddForce(_jumpForce * Vector3.up, ForceMode.Impulse);
        }
    }
}
