using UnityEngine;

namespace CodeBase.Infrastructure.GameStates
{
    [RequireComponent(typeof(Rigidbody))]
    public sealed class SetSolverInteractionsOnAwake : MonoBehaviour
    {
        [SerializeField] [Min(0)] private int _solverInteraction = 6;

        private Rigidbody _rigidbody;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _rigidbody.solverIterations = _solverInteraction;
        }
    }
}