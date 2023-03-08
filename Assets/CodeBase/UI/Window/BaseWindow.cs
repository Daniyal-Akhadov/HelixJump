using UnityEngine;
using UnityEngine.UI;

namespace CodeBase.UI.Window
{
    public abstract class BaseWindow : MonoBehaviour
    {
        [SerializeField] private Button _closeButton;

        private void Awake()
        {
            OnAwake();
        }

        private void OnDestroy()
        {
            _closeButton.onClick.RemoveListener(OnButtonClick);
        }

        protected virtual void OnAwake()
        {
            _closeButton.onClick.AddListener(OnButtonClick);
        }

        protected virtual void OnButtonClick()
        {
            Destroy(gameObject);
        }
    }
}