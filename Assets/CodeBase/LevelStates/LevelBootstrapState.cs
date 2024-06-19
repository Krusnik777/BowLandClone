using CodeBase.Configs;
using CodeBase.Infrastructure.DependencyInjection;
using CodeBase.Infrastructure.StateMachine;
using CodeBase.Services.ConfigsProvider;
using CodeBase.Services.GameFactory;
using CodeBase.Services.Input;
using CodeBase.Services.LevelStateMachine;
using CodeBase.Services.ProgressSaver;
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

        public void Enter()
        {
            Debug.Log("LEVEL: Init");

            progressSaver.ClearObjects();

            inputService.Enabled = true;

            string sceneName = SceneManager.GetActiveScene().name;
            LevelConfig levelConfig = configsProvider.GetLevel(sceneName);

            /*
            EnemySpawner[] enemySpawners = GameObject.FindObjectsOfType<EnemySpawner>();
            for (int i = 0; i < enemySpawners.Length; i++)
            {
                enemySpawners[i].Spawn();
            }*/

            EnemySpawnerData[] enemySpawnerDatas = levelConfig.EnemySpawnerDatas.ToArray();

            for (int i = 0; i < enemySpawnerDatas.Length; i++)
            {
                gameFactory.CreateEnemy(enemySpawnerDatas[i].Id, enemySpawnerDatas[i].Position);
            }

            Vector3[] coinPositions = levelConfig.CoinPositions.ToArray();

            for (int i = 0;i < coinPositions.Length; i++)
            {
                gameFactory.CreateCoin(coinPositions[i]);
            }

            gameFactory.CreateHero(levelConfig.HeroSpawnPosition, Quaternion.identity);

            gameFactory.CreateFollowCamera().SetTarget(gameFactory.HeroObject.transform);

            gameFactory.CreateVirtualJoystick();

            progressSaver.LoadProgress();

            levelStateSwitcher.Enter<LevelResearchState>();
        }
    }
}
