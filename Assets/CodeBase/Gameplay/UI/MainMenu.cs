using CodeBase.GameStates;
using CodeBase.Infrastructure.DependencyInjection;
using CodeBase.Services.GameStateMachine;
using UnityEngine;
using UnityEngine.UI;

namespace CodeBase.Gameplay.UI
{
    public class MainMenu : MonoBehaviour
    {
        [SerializeField] private Button m_playButton;

        private IGameStateSwitcher gameStateSwitcher;

        [Inject]
        public void Construct(IGameStateSwitcher gameStateSwitcher)
        {
            this.gameStateSwitcher = gameStateSwitcher;
        }

        private void Start()
        {
            m_playButton.onClick.AddListener(OnPlayButtonClicked);
        }

        private void OnDestroy()
        {
            m_playButton.onClick.RemoveListener(OnPlayButtonClicked);
        }

        private void OnPlayButtonClicked()
        {
            gameStateSwitcher.Enter<LoadNextLevelState>();
        }
    }
}
