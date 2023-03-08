using UnityEngine;

namespace CodeBase.Logic.Camera
{
    [DisallowMultipleComponent]
    public class CameraFollower : MonoBehaviour
    {
        [SerializeField] private float _speed = 3f;
        [SerializeField] private Vector3 _offset = Vector3.forward;
        [SerializeField] private float _distance = 5f;
        [SerializeField] private float AdditiveBoundPositionY = 0.07f;

        private Transform _ball;
        private Transform _beam;
        private Vector3 _minimumBallPosition;

        private void LateUpdate()
        {
            if (_ball == null)
                return;

            if (_ball.transform.position.y < _minimumBallPosition.y - AdditiveBoundPositionY)
            {
                TrackTarget();
                SetMinimumTargetPosition();
            }
        }

        public void SetTarget(Transform ball, Transform beam)
        {
            _ball = ball.transform;
            _beam = beam;
            transform.position = GetCameraPosition();
            SetMinimumTargetPosition();
        }

        private void SetMinimumTargetPosition()
        {
            _minimumBallPosition = _ball.position;
        }

        private void TrackTarget()
        {
            transform.position = Vector3.Lerp(transform.position, GetCameraPosition(), _speed * Time.deltaTime);
            transform.LookAt(_ball.position);
        }

        private Vector3 GetCameraPosition()
        {
            Vector3 cameraPosition = _ball.position;
            Vector3 beamPosition = _beam.transform.position;
            beamPosition.y = _ball.transform.position.y;
            Vector3 direction = (beamPosition - _ball.transform.position).normalized;
            cameraPosition -= (direction + _offset) * _distance;
            return cameraPosition;
        }
    }
}