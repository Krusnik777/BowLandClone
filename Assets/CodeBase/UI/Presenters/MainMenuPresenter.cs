using CodeBase.GameStates;
using CodeBase.Services;
using CodeBase.UI.Services;
using CodeBase.UI.Windows;
using UnityEngine;

namespace CodeBase.UI.Presenters
{
    public class MainMenuPresenter : WindowPresenterBase<MainMenuWindow>
    {
        private IGameStateSwitcher gameStateSwitcher;
        private IProgressProvider progressProvider;
        private IConfigsProvider configsProvider;
        private IWindowsProvider windowsProvider;

        private MainMenuWindow window;

        public MainMenuPresenter(IGameStateSwitcher gameStateSwitcher, IProgressProvider progressProvider, IConfigsProvider configsProvider, IWindowsProvider windowsProvider)
        {
            this.gameStateSwitcher = gameStateSwitcher;
            this.progressProvider = progressProvider;
            this.configsProvider = configsProvider;
            this.windowsProvider = windowsProvider;
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
            window.EventOnShopButtonClicked += OnShopButtonClicked;
            window.EventOnCleanuped += OnWindowCleanuped;
        }

        private void OnWindowCleanuped()
        {
            window.EventOnPlayButtonClicked -= OnPlayButtonClicked;
            window.EventOnShopButtonClicked -= OnShopButtonClicked;
            window.EventOnCleanuped -= OnWindowCleanuped;
        }

        private void OnPlayButtonClicked()
        {
            gameStateSwitcher.Enter<LoadNextLevelState>();
        }

        private void OnShopButtonClicked()
        {
            window.Close();
            windowsProvider.Open(WindowId.ShopWindow);
        }
    }
}
