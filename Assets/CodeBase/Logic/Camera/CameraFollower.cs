using CodeBase.Logic.Player;
using UnityEngine;

namespace CodeBase.Logic.Camera
{
    public class CameraFollower : MonoBehaviour
    {
        [SerializeField] private float _speed = 3f;
        [SerializeField] private Vector3 _offset = Vector3.forward;
        [SerializeField] private float _distance = 5f;

        private Transform _target;
        private Beam _beam;
        private Vector3 _minimumBallPosition;

        private const float AdditiveBoundPositionY = 0.07f;

        private void Start()
        {
            SetTarget(FindObjectOfType<BallJumper>().transform);
            _beam = FindObjectOfType<Beam>();
            transform.position = GetCameraPosition();
            SetMinimumTargetPosition();
        }

        private void LateUpdate()
        {
            if (_target == null)
                return;

            if (_target.transform.position.y < _minimumBallPosition.y - AdditiveBoundPositionY)
            {
                TrackTarget();
                SetMinimumTargetPosition();
            }
        }

        public void SetTarget(Transform target)
        {
            _target = target;
        }

        private void SetMinimumTargetPosition()
        {
            _minimumBallPosition = _target.position;
        }

        private void TrackTarget()
        {
            transform.position = Vector3.Lerp(transform.position, GetCameraPosition(), _speed * Time.deltaTime);
            transform.LookAt(_target.position);
        }

        private Vector3 GetCameraPosition()
        {
            Vector3 cameraPosition = _target.position;
            Vector3 beamPosition = _beam.transform.position;
            beamPosition.y = _target.transform.position.y;
            Vector3 direction = (beamPosition - _target.transform.position).normalized;
            cameraPosition -= (direction + _offset) * _distance;
            return cameraPosition;
        }
    }
}