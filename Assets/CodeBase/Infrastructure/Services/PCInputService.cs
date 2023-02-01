using UnityEngine;

namespace CodeBase.Infrastructure.Services
{
    public class PCInputService : InputService
    {
        private const string Horizontal = "Horizontal";

        public override Vector3 Axis =>
            Vector3.right * Input.GetAxis(Horizontal);
    }
}