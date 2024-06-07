using CodeBase.Infrastructure.ServiceLocator;
using System;

namespace CodeBase.Services.SceneLoader
{
    public interface ISceneLoader : IService
    {
        void Load(string sceneName, Action onLoaded = null);
    }
}
