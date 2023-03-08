using UnityEngine;
using UnityEngine.UI;

namespace CodeBase.UI.Elements
{
    public class LevelBar : MonoBehaviour
    {
        [SerializeField] private Image _bar;

        public void SetValue(float current, float target)
        {
            _bar.fillAmount = Mathf.Abs(current) / Mathf.Abs(target);
        }
    }
}