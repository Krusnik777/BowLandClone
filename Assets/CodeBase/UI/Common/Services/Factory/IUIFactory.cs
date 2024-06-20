using CodeBase.Configs;
using CodeBase.Infrastructure.DependencyInjection;
using CodeBase.UI.Elements;
using CodeBase.UI.Presenters;
using System.Threading.Tasks;
using UnityEngine;

namespace CodeBase.UI.Services
{
    public interface IUIFactory : IService
    {
        Transform UIRoot { get; set; }

        Task WarmUp();
        Task<LevelResultPresenter> CreateLevelResultWindowAsync(WindowConfig config);
        Task<MainMenuPresenter> CreateMainMenuPresenterAsync(WindowConfig config);
        Task<ShopPresenter> CreateShopPresenterAsync(WindowConfig config);
        Task<ShopItem> CreateShopItemAsync();
        void CreateUIRoot();
    }
}