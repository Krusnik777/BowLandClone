using CodeBase.Configs;
using CodeBase.Gameplay.Enemy;
using CodeBase.Gameplay.Hero;
using CodeBase.Infrastructure.DependencyInjection;
using CodeBase.Infrastructure.Services;
using CodeBase.UI.Elements;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace CodeBase.Services
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

        public async Task WarmUp()
        {
            EnemyConfig[] enemyConfigs = configsProvider.GetAllEnemies();

            for (int i = 0; i < enemyConfigs.Length; i++)
            {
                await assetProvider.Load<GameObject>(enemyConfigs[i].PrefabReference);
            }
        }

        public async Task<GameObject> CreateHeroAsync(Vector3 position, Quaternion rotation)
        {
            //GameObject heroPrefab = assetProvider.GetPrefab<GameObject>(AssetAddress.HeroAddress);
            HeroObject = await InstantiateAndInject(AssetAddress.HeroAddress);

            HeroObject.transform.position = position;
            HeroObject.transform.rotation = rotation;

            HeroHealth = HeroObject.GetComponent<HeroHealth>();

            HeroCondition = HeroObject.GetComponent<HeroCondition>();

            progressSaver.AddObject(HeroObject);

            return HeroObject;
        }

        public async Task<VirtualJoystick> CreateVirtualJoystickAsync()
        {
            //VirtualJoystick = CreateObject<VirtualJoystick>(AssetAddress.VirtualJoystickAddress);
            VirtualJoystick = await InstantiateAndInject<VirtualJoystick>(AssetAddress.VirtualJoystickAddress);

            return VirtualJoystick;
        }

        public async Task<FollowCamera> CreateFollowCameraAsync()
        {
            //FollowCamera = CreateObject<FollowCamera>(AssetAddress.FollowCameraAddress);
            FollowCamera = await InstantiateAndInject<FollowCamera>(AssetAddress.FollowCameraAddress);

            return FollowCamera;
        }

        public async Task<GameObject> CreateCoinAsync(Vector3 position)
        {
            //GameObject coinPrefab = assetProvider.GetPrefab<GameObject>(AssetAddress.CoinAddress);
            GameObject coin = await InstantiateAndInject(AssetAddress.CoinAddress);

            coin.transform.position = position;

            return coin;
        }

        public async Task<GameObject> CreateEnemyAsync(EnemyId id, Vector3 position)
        {
            EnemyConfig enemyConfig = configsProvider.GetEnemy(id);

            GameObject enemyPrefab = await assetProvider.Load<GameObject>(enemyConfig.PrefabReference);
            GameObject enemy = dIContainer.Instantiate(enemyPrefab);

            enemy.transform.position = position;

            IEnemyConfigInstaller[] enemyConfigInstallers = enemy.GetComponentsInChildren<IEnemyConfigInstaller>();

            for (int i = 0; i < enemyConfigInstallers.Length; i++)
            {
                enemyConfigInstallers[i].InstallConfig(enemyConfig);
            }

            return enemy;
        }

        private T CreateObject<T>(string prefabPath) where T : Object
        {
            GameObject gameObjectPrefab = assetProvider.GetPrefab<GameObject>(prefabPath);

            return dIContainer.Instantiate(gameObjectPrefab).GetComponent<T>();
        }

        private async Task<GameObject> InstantiateAndInject(string address)
        {
            GameObject newGameObject = await Addressables.InstantiateAsync(address).Task;
            dIContainer.InjectToGameObject(newGameObject);

            return newGameObject;
        }

        private async Task<T> InstantiateAndInject<T>(string address) where T : Object
        {
            GameObject gameObject = await InstantiateAndInject(address);

            return gameObject.GetComponent<T>();
        }
    }
}
