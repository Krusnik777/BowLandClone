using CodeBase.Configs;
using CodeBase.Infrastructure.DependencyInjection;
using CodeBase.Infrastructure.StateMachine;
using CodeBase.Services;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace CodeBase.LevelStates
{
    public class LevelBootstrapState : IEnterableState, IService
    {
        private IGameFactory gameFactory;
        private ILevelStateSwitcher levelStateSwitcher;
        private IInputService inputService;
        private IConfigsProvider configsProvider;
        private IProgressSaver progressSaver;

        public LevelBootstrapState(IGameFactory gameFactory, ILevelStateSwitcher levelStateSwitcher,
            IInputService inputService, IConfigsProvider configsProvider, IProgressSaver progressSaver)
        {
            this.gameFactory = gameFactory;
            this.levelStateSwitcher = levelStateSwitcher;
            this.inputService = inputService;
            this.configsProvider = configsProvider;
            this.progressSaver = progressSaver;
        }

        public async void Enter()
        {
            Debug.Log("LEVEL: Init");

            progressSaver.ClearObjects();

            await gameFactory.WarmUp();

            string sceneName = SceneManager.GetActiveScene().name;
            LevelConfig levelConfig = configsProvider.GetLevel(sceneName);

            /*
            EnemySpawner[] enemySpawners = GameObject.FindObjectsOfType<EnemySpawner>();
            for (int i = 0; i < enemySpawners.Length; i++)
            {
                enemySpawners[i].Spawn();
            }*/

            await gameFactory.CreateHeroAsync(levelConfig.HeroSpawnPosition, Quaternion.identity);

            FollowCamera followCamera = await gameFactory.CreateFollowCameraAsync();
            followCamera.SetTarget(gameFactory.HeroObject.transform);

            await gameFactory.CreateVirtualJoystickAsync();

            Vector3[] coinPositions = levelConfig.CoinPositions.ToArray();

            for (int i = 0; i < coinPositions.Length; i++)
            {
                await gameFactory.CreateCoinAsync(coinPositions[i]);
            }

            EnemySpawnerData[] enemySpawnerDatas = levelConfig.EnemySpawnerDatas.ToArray();

            for (int i = 0; i < enemySpawnerDatas.Length; i++)
            {
                await gameFactory.CreateEnemyAsync(enemySpawnerDatas[i].Id, enemySpawnerDatas[i].Position);
            }

            progressSaver.LoadProgress();

            inputService.Enabled = true;

            levelStateSwitcher.Enter<LevelResearchState>();
        }
    }
}
