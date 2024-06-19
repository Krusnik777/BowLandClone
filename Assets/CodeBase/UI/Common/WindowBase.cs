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

        public void Close()
        {
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
            m_closeButton?.onClick.AddListener(OnClose);
        }

        private void OnDestroy()
        {
            m_closeButton?.onClick.RemoveListener(OnClose);
            OnCleanup();
            EventOnCleanuped?.Invoke();
        }
    }
}
