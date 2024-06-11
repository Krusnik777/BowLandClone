using UnityEngine;

namespace CodeBase.Infrastructure.DependencyInjection
{
    public abstract class MonoInstaller : MonoBehaviour
    {
        protected DIContainer dIContainer;

        [Inject]
        public void Construct(DIContainer dIContainer)
        {
            this.dIContainer = dIContainer;
        }

        public virtual void InstallBindings() { }
    }
}
