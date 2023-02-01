using UnityEngine;

namespace CodeBase.Infrastructure.Services
{
    public abstract class InputService : IInputService
    {
        public abstract Vector3 Axis { get; }
    }
}