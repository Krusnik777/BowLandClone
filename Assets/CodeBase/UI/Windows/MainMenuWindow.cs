using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace CodeBase.UI.Windows
{
    public class MainMenuWindow : WindowBase
    {
        [SerializeField] private string m_buttonLabelPrefix = "Start Level ";
        [SerializeField] private Text m_levelNumberText;
        [SerializeField] private Button m_playButton;
        [SerializeField] private Button m_shopButton;

        public event UnityAction EventOnPlayButtonClicked;
        public event UnityAction EventOnShopButtonClicked;

        public void SetLevelNumberLabel(int levelIndex)
        {
            m_levelNumberText.text = m_buttonLabelPrefix + (levelIndex + 1);
        }

        public void HidePlayButton()
        {
            m_playButton.gameObject.SetActive(false);
        }

        protected override void OnClose()
        {
            Destroy(gameObject);
        }

        private void Start()
        {
            m_playButton.onClick.AddListener(() => EventOnPlayButtonClicked?.Invoke());
            m_shopButton.onClick.AddListener(() => EventOnShopButtonClicked?.Invoke());
        }
    }
}
