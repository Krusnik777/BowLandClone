using UnityEngine;

namespace CodeBase.Infrastructure.DependencyInjection
{
    public abstract class Context : MonoBehaviour
    {
        [SerializeField] protected MonoInstaller[] m_monoInstallers;
        [SerializeField] protected MonoBootstrapper m_contextBootstrapper;

        protected void InstallBindings()
        {
            if (m_monoInstallers == null) return;

            for (int i = 0; i < m_monoInstallers.Length; i++)
            {
                m_monoInstallers[i]?.InstallBindings();
            }
        }

        protected void OnBindResolved()
        {
            m_contextBootstrapper?.OnBindResolved();
        }
    }
}
