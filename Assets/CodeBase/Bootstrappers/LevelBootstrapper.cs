using CodeBase.Gameplay.Hero;
using CodeBase.Infrastructure.AssetManagement;
using CodeBase.Infrastructure.EntryPoints;
using CodeBase.Infrastructure.ServiceLocator;
using UnityEngine;

namespace CodeBase.Bootstrappers
{
    public class LevelBootstrapper : MonoBootstrapper
    {
        private IAssetProvider assetProvider;
        private HeroSpawnPoint heroSpawnPoint;

        public override void Bootstrap()
        {
            Debug.Log("LEVEL: Init");

            GetServices();

            GameObject hero = assetProvider.Instantiate<GameObject>(AssetPath.HeroPath);
            hero.transform.position = heroSpawnPoint.transform.position;
            hero.transform.rotation = heroSpawnPoint.transform.rotation;

            FollowCamera followCamera = assetProvider.Instantiate<FollowCamera>(AssetPath.FollowCameraPath);
            followCamera.SetTarget(hero.transform);

            assetProvider.Instantiate<GameObject>(AssetPath.VirtualJoystickPath);
        }

        private void GetServices()
        {
            assetProvider = AllServices.Container.Single<IAssetProvider>();
            heroSpawnPoint = AllServices.Container.Single<HeroSpawnPoint>();
        }
    }
}
