using CodeBase.Configs;
using CodeBase.Services;
using CodeBase.UI.Windows;

namespace CodeBase.UI.Services
{
    public class WindowsProvider : IWindowsProvider
    {
        private IUIFactory uIFactory;
        private IConfigsProvider configsProvider;

        public WindowsProvider(IUIFactory uIFactory, IConfigsProvider configsProvider)
        {
            this.uIFactory = uIFactory;
            this.configsProvider = configsProvider;
        }

        public void Open(WindowId windowId)
        {
            if (uIFactory.UIRoot == null) uIFactory.CreateUIRoot();

            WindowConfig windowConfig = configsProvider.GetWindow(windowId);

            if (windowId == WindowId.VictoryWindow || windowId == WindowId.DefeatWindow)
            {
                uIFactory.CreateLevelResultWindowAsync(windowConfig);
            }

            if (windowId == WindowId.MainMenuWindow)
            {
                uIFactory.CreateMainMenuPresenterAsync(windowConfig);
            }

            if (windowId == WindowId.ShopWindow)
            {
                uIFactory.CreateShopPresenterAsync(windowConfig);
            }
        }
    }
}
