using UnityEngine;

namespace CodeBase.Infrastructure.DependencyInjection
{
    public class ProjectContext : Context
    {
        private static ProjectContext _instance;
        public static bool Initialized => _instance != null;

        private DIContainer dIContainer;

        public static void InjectToGameObject(GameObject gameObject)
        {
            _instance.dIContainer.InjectToGameObject(gameObject);
        }

        public static void InjectToAllMonoBehaviours()
        {
            _instance.dIContainer.InjectToAllMonoBehaviours();
        }

        public static void InjectToInstallers(MonoInstaller[] monoInstallers)
        {
            for (int i = 0; i < monoInstallers.Length; i++)
                _instance.dIContainer.InjectToMonoBehaviour(monoInstallers[i]);
        }

        private void Awake()
        {
            if (_instance == null)
            {
                _instance = this;

                CreateDIContainer();

                InjectToInstallers(m_monoInstallers);

                InstallBindings();

                dIContainer.InjectToGameObject(gameObject);

                OnBindResolved();

                DontDestroyOnLoad(gameObject);

                return;
            }

            Destroy(gameObject);
        }

        private void CreateDIContainer()
        {
            dIContainer = new DIContainer();
            dIContainer.RegisterSingle(dIContainer);
        }
    }
}
