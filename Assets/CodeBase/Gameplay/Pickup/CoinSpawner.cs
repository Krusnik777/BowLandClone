using CodeBase.Infrastructure.DependencyInjection;
using CodeBase.Services;
using UnityEngine;

namespace CodeBase.Gameplay.Pickup
{
    public class CoinSpawner : MonoBehaviour
    {
        private IGameFactory gameFactory;

        [Inject]
        public void Construct(IGameFactory gameFactory)
        {
            this.gameFactory = gameFactory;
        }

        public void Spawn()
        {
            gameFactory.CreateCoinAsync(transform.position);
        }

#if UNITY_EDITOR

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.green;
            Gizmos.DrawSphere(transform.position, 0.25f);
        }

#endif
    }
}
