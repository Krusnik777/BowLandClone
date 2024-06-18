using CodeBase.Gameplay.Hero;
using CodeBase.Infrastructure.AssetManagement;
using CodeBase.Infrastructure.DependencyInjection;
using UnityEngine;

namespace CodeBase.Services.GameFactory
{
    public class GameFactory : IGameFactory
    {
        private IAssetProvider assetProvider;
        private DIContainer dIContainer;

        public GameObject HeroObject { get; private set; }

        public VirtualJoystick VirtualJoystick { get; private set; }

        public FollowCamera FollowCamera { get; private set; }

        public HeroHealth HeroHealth { get; private set; }

        public GameFactory(IAssetProvider assetProvider, DIContainer dIContainer)
        {
            this.assetProvider = assetProvider;
            this.dIContainer = dIContainer;
        }

        public GameObject CreateHero(Vector3 position, Quaternion rotation)
        {
            GameObject heroPrefab = assetProvider.GetPrefab<GameObject>(AssetPath.HeroPath);
            HeroObject = dIContainer.Instantiate(heroPrefab);

            HeroObject.transform.position = position;
            HeroObject.transform.rotation = rotation;

            HeroHealth = HeroObject.GetComponent<HeroHealth>();

            return HeroObject;
        }

        public VirtualJoystick CreateVirtualJoystick()
        {
            /*
            GameObject virtualJoystickPrefab = assetProvider.GetPrefab<GameObject>(AssetPath.VirtualJoystickPath);

            VirtualJoystick = dIContainer.Instantiate(virtualJoystickPrefab).GetComponent<VirtualJoystick>();
            */

            VirtualJoystick = CreateObject<VirtualJoystick>(AssetPath.VirtualJoystickPath);

            return VirtualJoystick;
        }

        public FollowCamera CreateFollowCamera()
        {
            /*
            GameObject followCameraPrefab = assetProvider.GetPrefab<GameObject>(AssetPath.FollowCameraPath);

            FollowCamera = dIContainer.Instantiate(followCameraPrefab).GetComponent<FollowCamera>();
            */

            FollowCamera = CreateObject<FollowCamera>(AssetPath.FollowCameraPath);

            return FollowCamera;
        }

        public GameObject CreateEnemy(string path, Vector3 position)
        {
            GameObject enemyPrefab = assetProvider.GetPrefab<GameObject>(path);

            GameObject enemy = dIContainer.Instantiate(enemyPrefab);

            enemy.transform.position = position;

            return enemy;
        }

        private T CreateObject<T>(string prefabPath) where T : Object
        {
            GameObject gameObjectPrefab = assetProvider.GetPrefab<GameObject>(prefabPath);

            return dIContainer.Instantiate(gameObjectPrefab).GetComponent<T>();
        }
    }
}
