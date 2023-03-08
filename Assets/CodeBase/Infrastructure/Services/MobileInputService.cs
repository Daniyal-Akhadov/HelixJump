using UnityEngine;

namespace CodeBase.Infrastructure.Services
{
    public class MobileInputService : InputService
    {
        public override Vector3 Axis
        {
            get
            {
                Vector3 result = Vector3.zero;

                if (IsBlock == false && Input.touchCount > 0)
                {
                    Touch touch = Input.GetTouch(0);

                    if (touch.phase == TouchPhase.Moved)
                    {
                        result = touch.deltaPosition;
                    }
                }

                return result;
            }
        }
    }
}