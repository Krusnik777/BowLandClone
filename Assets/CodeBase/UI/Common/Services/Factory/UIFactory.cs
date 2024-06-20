using CodeBase.Configs;
using CodeBase.Infrastructure.DependencyInjection;
using CodeBase.Infrastructure.Services;
using CodeBase.Services;
using CodeBase.UI.Elements;
using CodeBase.UI.Presenters;
using CodeBase.UI.Windows;
using System.Threading.Tasks;
using UnityEngine;

namespace CodeBase.UI.Services
{
    public class UIFactory : IUIFactory
    {
        private const string UIRootGameObjectName = "UIRoot";

        public Transform UIRoot { get; set; }

        private DIContainer dIContainer;
        private IAssetProvider assetProvider;
        private IConfigsProvider configsProvider;

        public UIFactory(DIContainer dIContainer, IAssetProvider assetProvider, IConfigsProvider configsProvider)
        {
            this.dIContainer = dIContainer;
            this.assetProvider = assetProvider;
            this.configsProvider = configsProvider;
        }

        public async Task WarmUp()
        {
            await assetProvider.Load<GameObject>(configsProvider.GetWindow(WindowId.MainMenuWindow).PrefabReference);
            await assetProvider.Load<GameObject>(configsProvider.GetWindow(WindowId.VictoryWindow).PrefabReference);
            await assetProvider.Load<GameObject>(configsProvider.GetWindow(WindowId.DefeatWindow).PrefabReference);
            await assetProvider.Load<GameObject>(configsProvider.GetWindow(WindowId.ShopWindow).PrefabReference);
        }

        public async Task<LevelResultPresenter> CreateLevelResultWindowAsync(WindowConfig config)
        {
            return await CreateWindowAsync<LevelResultWindow, LevelResultPresenter>(config);
        }

        public async Task<MainMenuPresenter> CreateMainMenuPresenterAsync(WindowConfig config)
        {
            return await CreateWindowAsync<MainMenuWindow, MainMenuPresenter>(config);
        }

        public async Task<ShopPresenter> CreateShopPresenterAsync(WindowConfig config)
        {
            return await CreateWindowAsync<ShopWindow, ShopPresenter>(config);
        }
        public async Task<ShopItem> CreateShopItemAsync()
        {
            GameObject prefab = await assetProvider.Load<GameObject>(AssetAddress.ShopItemAddress);
            GameObject shopItemGameObject = dIContainer.Instantiate(prefab);

            return shopItemGameObject.GetComponent<ShopItem>();
        }

        public void CreateUIRoot()
        {
            UIRoot = new GameObject(UIRootGameObjectName).transform;
        }

        private async Task<TPresenter> CreateWindowAsync<TWindow, TPresenter>(WindowConfig config) where TWindow : WindowBase where TPresenter : WindowPresenterBase<TWindow>
        {
            GameObject prefab = await assetProvider.Load<GameObject>(config.PrefabReference);

            TWindow window = dIContainer.Instantiate(prefab).GetComponent<TWindow>();
            window.transform.SetParent(UIRoot);
            window.SetTitle(config.Title);

            TPresenter presenter = dIContainer.CreateAndInject<TPresenter>();
            presenter.SetWindow(window);

            return presenter;
        }

    }
}
