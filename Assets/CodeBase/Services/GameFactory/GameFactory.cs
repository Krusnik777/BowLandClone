using CodeBase.Configs;
using CodeBase.Gameplay.Enemy;
using CodeBase.Gameplay.Hero;
using CodeBase.Infrastructure.AssetManagement;
using CodeBase.Infrastructure.DependencyInjection;
using CodeBase.Services.ConfigsProvider;
using CodeBase.Services.ProgressSaver;
using CodeBase.UI.Elements;
using UnityEngine;

namespace CodeBase.Services.GameFactory
{
    public class GameFactory : IGameFactory
    {
        private IAssetProvider assetProvider;
        private DIContainer dIContainer;
        private IConfigsProvider configsProvider;
        private IProgressSaver progressSaver;

        public GameObject HeroObject { get; private set; }

        public VirtualJoystick VirtualJoystick { get; private set; }

        public FollowCamera FollowCamera { get; private set; }

        public HeroHealth HeroHealth { get; private set; }

        public HeroCondition HeroCondition { get; private set; }

        public GameFactory(IAssetProvider assetProvider, DIContainer dIContainer, IConfigsProvider configsProvider, IProgressSaver progressSaver)
        {
            this.assetProvider = assetProvider;
            this.dIContainer = dIContainer;
            this.configsProvider = configsProvider;
            this.progressSaver = progressSaver;
        }

        public GameObject CreateHero(Vector3 position, Quaternion rotation)
        {
            GameObject heroPrefab = assetProvider.GetPrefab<GameObject>(AssetPath.HeroPath);
            HeroObject = dIContainer.Instantiate(heroPrefab);

            HeroObject.transform.position = position;
            HeroObject.transform.rotation = rotation;

            HeroHealth = HeroObject.GetComponent<HeroHealth>();

            HeroCondition = HeroObject.GetComponent<HeroCondition>();

            progressSaver.AddObject(HeroObject);

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

        public GameObject CreateEnemy(EnemyId id, Vector3 position)
        {
            EnemyConfig enemyConfig = configsProvider.GetConfig(id);
            GameObject enemyPrefab = enemyConfig.Prefab;
            GameObject enemy = dIContainer.Instantiate(enemyPrefab);

            enemy.transform.position = position;

            IEnemyConfigInstaller[] enemyConfigInstallers = enemy.GetComponentsInChildren<IEnemyConfigInstaller>();

            for (int i = 0; i < enemyConfigInstallers.Length; i++)
            {
                enemyConfigInstallers[i].InstallConfig(enemyConfig);
            }

            return enemy;
        }

        public GameObject CreateCoin(Vector3 position)
        {
            GameObject coinPrefab = assetProvider.GetPrefab<GameObject>(AssetPath.CoinPath);
            GameObject coin = dIContainer.Instantiate(coinPrefab);

            coin.transform.position = position;

            return coin;
        }

        private T CreateObject<T>(string prefabPath) where T : Object
        {
            GameObject gameObjectPrefab = assetProvider.GetPrefab<GameObject>(prefabPath);

            return dIContainer.Instantiate(gameObjectPrefab).GetComponent<T>();
        }
    }
}
