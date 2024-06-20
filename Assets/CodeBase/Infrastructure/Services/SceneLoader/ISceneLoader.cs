using CodeBase.Infrastructure.DependencyInjection;
using System;

namespace CodeBase.Infrastructure.Services
{
    public interface ISceneLoader : IService
    {
        void Load(string sceneName, Action onLoaded = null);
    }
}
