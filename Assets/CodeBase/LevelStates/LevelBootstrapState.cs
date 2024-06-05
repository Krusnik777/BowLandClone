using CodeBase.Gameplay.Hero;
using CodeBase.Infrastructure.AssetManagement;
using CodeBase.Infrastructure.ServiceLocator;
using CodeBase.Infrastructure.StateMachine;
using UnityEngine;

namespace CodeBase.LevelStates
{
    public class LevelBootstrapState : IEnterableState, IService
    {
        private IAssetProvider assetProvider;
        private HeroSpawnPoint heroSpawnPoint;

        public LevelBootstrapState(IAssetProvider assetProvider, HeroSpawnPoint heroSpawnPoint)
        {
            this.assetProvider = assetProvider;
            this.heroSpawnPoint = heroSpawnPoint;
        }

        public void Enter()
        {
            Debug.Log("LEVEL: Init");

            GameObject hero = assetProvider.Instantiate<GameObject>(AssetPath.HeroPath);
            hero.transform.position = heroSpawnPoint.transform.position;
            hero.transform.rotation = heroSpawnPoint.transform.rotation;

            FollowCamera followCamera = assetProvider.Instantiate<FollowCamera>(AssetPath.FollowCameraPath);
            followCamera.SetTarget(hero.transform);

            assetProvider.Instantiate<GameObject>(AssetPath.VirtualJoystickPath);
        }
    }
}
