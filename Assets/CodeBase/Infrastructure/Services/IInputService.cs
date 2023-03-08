using UnityEngine;

namespace CodeBase.Infrastructure.Services
{
    public interface IInputService : IService
    {
        Vector3 Axis { get; }
        void Allow();
        void Block();
    }
}