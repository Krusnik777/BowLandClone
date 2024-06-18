using CodeBase.Gameplay.Enemy;
using CodeBase.Gameplay.Hero;
using CodeBase.Infrastructure.DependencyInjection;
using CodeBase.Infrastructure.StateMachine;
using CodeBase.Services.GameFactory;
using CodeBase.Services.Input;
using CodeBase.Services.LevelStateMachine;
using UnityEngine;

namespace CodeBase.LevelStates
{
    public class LevelBootstrapState : IEnterableState, IService
    {
        private IGameFactory gameFactory;
        private HeroSpawnPoint heroSpawnPoint;
        private ILevelStateSwitcher levelStateSwitcher;
        private IInputService inputService;

        public LevelBootstrapState(IGameFactory gameFactory, HeroSpawnPoint heroSpawnPoint, ILevelStateSwitcher levelStateSwitcher, IInputService inputService)
        {
            this.gameFactory = gameFactory;
            this.heroSpawnPoint = heroSpawnPoint;
            this.levelStateSwitcher = levelStateSwitcher;
            this.inputService = inputService;
        }

        public void Enter()
        {
            Debug.Log("LEVEL: Init");

            /*
            //GameObject hero = assetProvider.Instantiate<GameObject>(AssetPath.HeroPath);

            GameObject heroPrefab = assetProvider.GetPrefab<GameObject>(AssetPath.HeroPath);
            GameObject hero = dIContainer.Instantiate(heroPrefab);

            hero.transform.position = heroSpawnPoint.transform.position;
            hero.transform.rotation = heroSpawnPoint.transform.rotation;

            FollowCamera followCamera = assetProvider.Instantiate<FollowCamera>(AssetPath.FollowCameraPath);
            followCamera.SetTarget(hero.transform);

            assetProvider.Instantiate<GameObject>(AssetPath.VirtualJoystickPath);
            */

            inputService.Enabled = true;

            EnemySpawner[] enemySpawners = GameObject.FindObjectsOfType<EnemySpawner>();
            for (int i = 0; i < enemySpawners.Length; i++)
            {
                enemySpawners[i].Spawn();
            }

            gameFactory.CreateHero(heroSpawnPoint.transform.position, heroSpawnPoint.transform.rotation);

            gameFactory.CreateFollowCamera().SetTarget(gameFactory.HeroObject.transform);

            gameFactory.CreateVirtualJoystick();

            levelStateSwitcher.Enter<LevelResearchState>();
        }
    }
}
