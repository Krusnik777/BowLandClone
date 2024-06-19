using CodeBase.Infrastructure.DependencyInjection;
using CodeBase.Services.GameFactory;
using UnityEngine;

namespace CodeBase.Gameplay.Enemy
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private EnemyId m_enemyId;
        public EnemyId EnemyId => m_enemyId;

        private IGameFactory gameFactory;

        [Inject]
        public void Construct(IGameFactory gameFactory)
        {
            this.gameFactory = gameFactory;
        }

        public void Spawn()
        {
            gameFactory.CreateEnemy(m_enemyId, transform.position);
        }

        #if UNITY_EDITOR

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawSphere(transform.position, 0.5f);
        }

        #endif
    }
}
