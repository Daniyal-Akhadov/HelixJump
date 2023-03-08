using UnityEngine;

namespace CodeBase.Infrastructure.Services
{
    public class PCInputService : InputService
    {
        private const string Horizontal = "Horizontal";

        public override Vector3 Axis =>
            IsBlock == true ? Vector3.zero : Vector3.right * Input.GetAxis(Horizontal);
    }
}