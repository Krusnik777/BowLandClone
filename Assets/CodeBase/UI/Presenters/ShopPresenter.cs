using CodeBase.UI.Services;
using CodeBase.UI.Windows;

namespace CodeBase.UI.Presenters
{
    public class ShopPresenter : WindowPresenterBase<ShopWindow>
    {
        private IWindowsProvider windowsProvider;

        private ShopWindow window;

        public ShopPresenter(IWindowsProvider windowsProvider)
        {
            this.windowsProvider = windowsProvider;
        }

        public override void SetWindow(ShopWindow window)
        {
            this.window = window;

            window.EventOnClosed += OnWindowClosed;
            window.EventOnCleanuped += OnWindowCleanuped;
        }

        private void OnWindowCleanuped()
        {
            window.EventOnClosed -= OnWindowClosed;
            window.EventOnCleanuped -= OnWindowCleanuped;
        }

        private void OnWindowClosed()
        {
            windowsProvider.Open(WindowId.MainMenuWindow);
        }
    }
}
