using UnityEngine;

namespace CodeBase.Infrastructure.Services
{
    public abstract class InputService : IInputService
    {
        public abstract Vector3 Axis { get; }

        protected bool IsBlock { get; private set; }

        public void Allow()
        {
            IsBlock = false;
        }

        public void Block()
        {
            IsBlock = true;
        }
    }
}