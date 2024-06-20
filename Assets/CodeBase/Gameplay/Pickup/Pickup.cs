using CodeBase.Infrastructure.DependencyInjection;
using CodeBase.Services;
using UnityEngine;
using UnityEngine.Events;

namespace CodeBase.Gameplay.Pickup
{
    [RequireComponent(typeof(BoxCollider))]
    public class Pickup : MonoBehaviour
    {
        public event UnityAction EventOnPicked;

        private IGameFactory gameFactory;

        [Inject]
        public void Construct(IGameFactory gameFactory)
        {
            this.gameFactory = gameFactory;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (gameFactory == null) return;

            if (gameFactory.HeroObject == null) return;

            if (other.gameObject == gameFactory.HeroObject)
            {
                EventOnPicked?.Invoke();

                Destroy(gameObject);
            }
        }
    }
}
