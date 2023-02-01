using CodeBase.Infrastructure.Services;
using UnityEngine;

namespace CodeBase.Logic.Tower
{
    [RequireComponent(typeof(Rigidbody))]
    public class TowerRotator : MonoBehaviour
    {
        [SerializeField] private float _torque = 5f;

        private IInputService _inputService;
        private Vector3 _axis;
        private Rigidbody _rigidbody;
        
        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _inputService = AllServices.Container.Single<IInputService>();
        }

        private void Update()
        {
            _axis = _inputService.Axis;

            if (_axis.sqrMagnitude >= Constants.InputTreshold)
            {
                _axis.Normalize();
            }
        }

        private void FixedUpdate()
        {
            Rotate(direction: -_axis.x);
        }

        private void Rotate(float direction)
        {
            _rigidbody.AddTorque(Vector3.up * (direction * _torque * Time.fixedDeltaTime));
        }
    }
}