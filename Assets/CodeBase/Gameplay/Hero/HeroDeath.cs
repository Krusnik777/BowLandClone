using UnityEngine;

namespace CodeBase.Gameplay.Hero
{
    public class HeroDeath : MonoBehaviour
    {
        [SerializeField] private HeroHealth m_health;

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
