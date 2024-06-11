using UnityEngine;

namespace CodeBase.Infrastructure.DependencyInjection
{
    public abstract class MonoBootstrapper : MonoBehaviour
    {
        public abstract void OnBindResolved();
    }
}
