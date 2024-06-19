using CodeBase.GameStates;
using CodeBase.Services.GameStateMachine;
using CodeBase.UI.Windows;

namespace CodeBase.UI.Presenters
{
    public class LevelResultPresenter : WindowPresenterBase<LevelResultWindow>
    {
        private IGameStateSwitcher gameStateSwitcher;

        private LevelResultWindow window;

        public LevelResultPresenter(IGameStateSwitcher gameStateSwitcher)
        {
            this.gameStateSwitcher = gameStateSwitcher;
        }

        public override void SetWindow(LevelResultWindow window)
        {
            this.window = window;
            window.EventOnLoadMainMenuButtonClicked += OnLoadMainMenuButtonClicked;
            window.EventOnCleanuped += OnWindowCleanuped;
        }

        private void OnWindowCleanuped()
        {
            window.EventOnLoadMainMenuButtonClicked -= OnLoadMainMenuButtonClicked;
            window.EventOnCleanuped -= OnWindowCleanuped;
        }

        private void OnLoadMainMenuButtonClicked()
        {
            gameStateSwitcher.Enter<LoadMainMenuState>();
        }
    }
}
