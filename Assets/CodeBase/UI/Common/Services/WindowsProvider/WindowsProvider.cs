using CodeBase.Configs;
using CodeBase.Services.ConfigsProvider;
using CodeBase.UI.Services.Factory;
using CodeBase.UI.Windows;

namespace CodeBase.UI.Services.WindowsProvider
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

            WindowConfig windowConfig = configsProvider.GetConfig(windowId);

            if (windowId == WindowId.VictoryWindow || windowId == WindowId.DefeatWindow)
            {
                uIFactory.CreateLevelResultWindow(windowConfig);
            }

            if (windowId == WindowId.MainMenuWindow)
            {
                uIFactory.CreateMainMenuPresenter(windowConfig);
            }
        }
    }
}
