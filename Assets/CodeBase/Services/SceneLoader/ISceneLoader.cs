using CodeBase.Infrastructure.ServiceLocator;


namespace CodeBase.Services.SceneLoader
{
    public interface ISceneLoader : IService
    {
        void Load(string sceneName);
    }
}
