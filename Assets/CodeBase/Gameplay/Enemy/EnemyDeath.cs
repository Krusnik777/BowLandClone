using UnityEngine;

namespace CodeBase.Gameplay.Enemy
{
    public class EnemyDeath : MonoBehaviour
    {
        [SerializeField] private EnemyHealth m_health;

        private void Start()
        {
            m_health.EventOnDie += OnDie;
        }

        private void OnDestroy()
        {
            m_health.EventOnDie -= OnDie;
        }

        private void OnDie()
        {
            Destroy(gameObject);
        }
    }
}
