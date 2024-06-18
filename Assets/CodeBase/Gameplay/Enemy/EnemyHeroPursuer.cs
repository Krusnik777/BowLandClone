using CodeBase.Infrastructure.DependencyInjection;
using CodeBase.Services.GameFactory;
using UnityEngine;

namespace CodeBase.Gameplay.Enemy
{
    public class EnemyHeroPursuer : MonoBehaviour
    {
        [SerializeField] private EnemyFollowHero m_followHero;
        [SerializeField] private float m_viewRadius;

        private IGameFactory gameFactory;

        [Inject]
        public void Construct(IGameFactory gameFactory)
        {
            this.gameFactory = gameFactory;
        }

        private void Start()
        {
            m_followHero.enabled = false;
        }

        private void Update()
        {
            if (gameFactory.HeroObject == null) return;

            if (Vector3.Distance(m_followHero.transform.position, gameFactory.HeroObject.transform.position) <= m_viewRadius)
            {
                StartPursuit();
            }
            else
            {
                StopPursuit();
            }
        }

        private void StartPursuit()
        {
            m_followHero.enabled = true;
        }

        private void StopPursuit()
        {
            m_followHero.enabled = false;
        }


        #if UNITY_EDITOR

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(transform.position, m_viewRadius);
        }

        #endif
    }
}
