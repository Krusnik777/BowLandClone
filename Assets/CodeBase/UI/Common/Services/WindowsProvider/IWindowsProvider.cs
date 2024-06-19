using CodeBase.Infrastructure.DependencyInjection;
using CodeBase.UI.Windows;

namespace CodeBase.UI.Services.WindowsProvider
{
    public interface IWindowsProvider : IService
    {
        void Open(WindowId windowId);
    }
}