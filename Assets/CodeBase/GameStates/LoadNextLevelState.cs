using CodeBase.Infrastructure.DependencyInjection;
using CodeBase.Infrastructure.Services;
using CodeBase.Infrastructure.StateMachine;
using CodeBase.Services;
using UnityEngine;

namespace CodeBase.GameStates
{
    public class LoadNextLevelState : IEnterableState, IService
    {
        private ISceneLoader sceneLoader;
        private IProgressProvider progressProvider;
        private IConfigsProvider configsProvider;

        public LoadNextLevelState(ISceneLoader sceneLoader, IProgressProvider progressProvider, IConfigsProvider configsProvider)
        {
            this.sceneLoader = sceneLoader;
            this.progressProvider = progressProvider;
            this.configsProvider = configsProvider;
        }

        public void Enter()
        {
            int levelIndex = progressProvider.PlayerProgress.CurrentLevelIndex;
            levelIndex = Mathf.Clamp(levelIndex, 0, configsProvider.LevelsAmount - 1);
            string sceneName = configsProvider.GetLevel(levelIndex).SceneName;

            sceneLoader.Load(sceneName);
        }
    }
}
