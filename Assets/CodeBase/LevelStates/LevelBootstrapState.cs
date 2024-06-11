using CodeBase.Gameplay.Hero;
using CodeBase.Infrastructure.DependencyInjection;
using CodeBase.Infrastructure.StateMachine;
using CodeBase.Services.GameFactory;
using UnityEngine;

namespace CodeBase.LevelStates
{
    public class LevelBootstrapState : IEnterableState, IService
    {
        private IGameFactory gameFactory;
        private HeroSpawnPoint heroSpawnPoint;

        public LevelBootstrapState(IGameFactory gameFactory, HeroSpawnPoint heroSpawnPoint)
        {
            this.gameFactory = gameFactory;
            this.heroSpawnPoint = heroSpawnPoint;
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

            gameFactory.CreateHero(heroSpawnPoint.transform.position, heroSpawnPoint.transform.rotation);

            gameFactory.CreateFollowCamera().SetTarget(gameFactory.Hero.transform);

            gameFactory.CreateVirtualJoystick();
        }
    }
}
