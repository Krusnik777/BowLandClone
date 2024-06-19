using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace CodeBase.UI.Windows
{
    public class LevelResultWindow : WindowBase
    {
        [SerializeField] private Button m_loadMainMenuButton;

        public event UnityAction EventOnLoadMainMenuButtonClicked;

        private void Start()
        {
            m_loadMainMenuButton.onClick.AddListener(() => EventOnLoadMainMenuButtonClicked?.Invoke());
        }
    }
}
