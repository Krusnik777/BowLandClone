using UnityEngine;

namespace CodeBase.Infrastructure.EntryPoints
{
    public abstract class MonoInstaller : MonoBehaviour
    {
        [SerializeField] private MonoBootstrapper m_monoBootstrapper;

        private void Awake()
        {
            InstallBindings();

            m_monoBootstrapper?.Bootstrap();
        }

        protected virtual void InstallBindings() { }
    }
}
