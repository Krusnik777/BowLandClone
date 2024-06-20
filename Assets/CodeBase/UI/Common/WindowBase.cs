using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace CodeBase.UI
{
    public abstract class WindowBase : MonoBehaviour
    {
        [SerializeField] private Button m_closeButton;
        [SerializeField] private Text m_titleText;

        public event UnityAction EventOnCleanuped;
        public event UnityAction EventOnClosed;

        public void Close()
        {
            EventOnClosed?.Invoke();
            OnClose();
        }

        public void SetTitle(string title)
        {
            if (m_titleText == null) return;

            m_titleText.text = title;
        }

        protected virtual void OnAwake() { }
        protected virtual void OnClose() { }
        protected virtual void OnCleanup() { }

        private void Awake()
        {
            OnAwake();
            m_closeButton?.onClick.AddListener(Close);
        }

        private void OnDestroy()
        {
            m_closeButton?.onClick.RemoveListener(Close);
            OnCleanup();
            EventOnCleanuped?.Invoke();
        }
    }
}
