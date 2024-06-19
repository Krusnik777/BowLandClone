using CodeBase.Configs;
using CodeBase.Infrastructure.DependencyInjection;
using CodeBase.UI.Presenters;
using CodeBase.UI.Windows;
using UnityEngine;

namespace CodeBase.UI.Services.Factory
{
    public class UIFactory : IUIFactory
    {
        private const string UIRootGameObjectName = "UIRoot";

        public Transform UIRoot { get; set; }

        private DIContainer dIContainer;

        public UIFactory(DIContainer dIContainer)
        {
            this.dIContainer = dIContainer;
        }

        public LevelResultPresenter CreateLevelResultWindow(WindowConfig config)
        {
            return CreateWindow<LevelResultWindow, LevelResultPresenter>(config);
        }

        public MainMenuPresenter CreateMainMenuPresenter(WindowConfig config)
        {
            return CreateWindow<MainMenuWindow, MainMenuPresenter>(config);
        }

        public void CreateUIRoot()
        {
            UIRoot = new GameObject(UIRootGameObjectName).transform;
        }

        private TPresenter CreateWindow<TWindow, TPresenter>(WindowConfig config) where TWindow : WindowBase where TPresenter : WindowPresenterBase<TWindow>
        {
            TWindow window = dIContainer.Instantiate(config.Prefab).GetComponent<TWindow>();
            window.transform.SetParent(UIRoot);
            window.SetTitle(config.Title);

            TPresenter presenter = dIContainer.CreateAndInject<TPresenter>();
            presenter.SetWindow(window);

            return presenter;
        }

    }
}
