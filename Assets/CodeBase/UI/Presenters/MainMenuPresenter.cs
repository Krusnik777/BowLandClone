using CodeBase.GameStates;
using CodeBase.Services.ConfigsProvider;
using CodeBase.Services.GameStateMachine;
using CodeBase.Services.ProgressProvider;
using CodeBase.UI.Windows;

namespace CodeBase.UI.Presenters
{
    public class MainMenuPresenter : WindowPresenterBase<MainMenuWindow>
    {
        private IGameStateSwitcher gameStateSwitcher;
        private IProgressProvider progressProvider;
        private IConfigsProvider configsProvider;

        private MainMenuWindow window;

        public MainMenuPresenter(IGameStateSwitcher gameStateSwitcher, IProgressProvider progressProvider, IConfigsProvider configsProvider)
        {
            this.gameStateSwitcher = gameStateSwitcher;
            this.progressProvider = progressProvider;
            this.configsProvider = configsProvider;
        }

        public override void SetWindow(MainMenuWindow window)
        {
            this.window = window;

            int currentLevelIndex = progressProvider.PlayerProgress.CurrentLevelIndex;

            if (currentLevelIndex == configsProvider.LevelsAmount)
            {
                window.HidePlayButton();
            }
            else
            {
                window.SetLevelNumberLabel(currentLevelIndex);
            }

            window.EventOnPlayButtonClicked += OnPlayButtonClicked;
            window.EventOnCleanuped += OnWindowCleanuped;
        }

        private void OnWindowCleanuped()
        {
            window.EventOnPlayButtonClicked -= OnPlayButtonClicked;
            window.EventOnCleanuped -= OnWindowCleanuped;
        }

        private void OnPlayButtonClicked()
        {
            gameStateSwitcher.Enter<LoadNextLevelState>();
        }
    }
}
