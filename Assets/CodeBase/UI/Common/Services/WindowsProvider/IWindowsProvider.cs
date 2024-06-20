using CodeBase.Infrastructure.DependencyInjection;
using CodeBase.UI.Windows;

namespace CodeBase.UI.Services
{
    public interface IWindowsProvider : IService
    {
        void Open(WindowId windowId);
    }
}