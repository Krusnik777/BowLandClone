using CodeBase.Configs;
using CodeBase.Gameplay.Hero;
using CodeBase.Infrastructure.DependencyInjection;
using CodeBase.Services.GameFactory;
using UnityEngine;
using UnityEngine.AI;

namespace CodeBase.Gameplay.Enemy
{
    public class EnemyMeleeAttack : MonoBehaviour, IEnemyConfigInstaller
    {
        [SerializeField] private NavMeshAgent m_agent;
        [SerializeField] private EnemyAnimator m_animator;
        [SerializeField] private float m_cooldown;
        [SerializeField] private float m_radius;
        [SerializeField] private float m_damage;

        private IGameFactory gameFactory;
        private HeroHealth heroHealth;

        private float timer;

        [Inject]
        public void Construct(IGameFactory gameFactory)
        {
            this.gameFactory = gameFactory;
        }

        public void InstallConfig(EnemyConfig config)
        {
            m_cooldown = config.AttackCooldown;
            m_radius = config.AttackRadius;
            m_damage = config.Damage;
        }

        private void Start()
        {
            heroHealth = gameFactory.HeroHealth;
        }

        private void Update()
        {
            if (heroHealth == null) return;

            timer += Time.deltaTime;

            if (CanAttack())
            {
                StartAttack();
            }
        }

        private bool CanAttack()
        {
            return timer >= m_cooldown && m_agent.velocity.magnitude <= 0.1f && Vector3.Distance(transform.position, heroHealth.transform.position) <= m_radius;
        }

        private void StartAttack()
        {
            timer = 0;
            m_animator.PlayAttack();
        }

        private void AnimationEventOnHit()
        {
            if (heroHealth != null)
            {
                heroHealth.ApplyDamage(m_damage);
            }
        }

        #if UNITY_EDITOR

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, m_radius);
        }

        #endif
    }
}
