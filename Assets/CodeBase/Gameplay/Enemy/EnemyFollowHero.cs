using CodeBase.Infrastructure.DependencyInjection;
using CodeBase.Services.GameFactory;
using UnityEngine;
using UnityEngine.AI;

namespace CodeBase.Gameplay.Enemy
{
    public class EnemyFollowHero : MonoBehaviour
    {
        [SerializeField] private float m_movementSpeed;
        [SerializeField] private float m_stopDistance;
        [SerializeField] private NavMeshAgent m_agent;

        private IGameFactory gameFactory;

        [Inject]
        public void Construct(IGameFactory gameFactory)
        {
            this.gameFactory = gameFactory;
        }

        private void Start()
        {
            m_agent.speed = m_movementSpeed;
            m_agent.stoppingDistance = m_stopDistance;
            m_agent.Warp(transform.position);
        }

        private void Update()
        {
            if (gameFactory.HeroObject == null) return;

            if (Vector3.Distance(m_agent.transform.position, gameFactory.HeroObject.transform.position) <= m_stopDistance) return;

            m_agent.destination = gameFactory.HeroObject.transform.position;
        }
    }
}