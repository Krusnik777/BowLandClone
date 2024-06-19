using CodeBase.Configs;
using CodeBase.Infrastructure.DependencyInjection;
using CodeBase.UI.Presenters;
using UnityEngine;

namespace CodeBase.UI.Services.Factory
{
    public interface IUIFactory : IService
    {
        Transform UIRoot { get; set; }

        LevelResultPresenter CreateLevelResultWindow(WindowConfig config);
        MainMenuPresenter CreateMainMenuPresenter(WindowConfig config);
        void CreateUIRoot();
    }
}