using CodeBase.Data;
using CodeBase.Services;
using UnityEngine;

namespace CodeBase.Gameplay.Hero
{
    public class HeroHealth : Health, IProgressLoadHandler
    {
        [SerializeField] private float m_restoreHealthAmount;
        [SerializeField] private float m_restoreDelay;

        private float restoreTimer;

        public void Load(PlayerProgress playerProgress)
        {
            m_maxValue = playerProgress.HeroStats.MaxHealth;
            m_currentValue = playerProgress.HeroStats.MaxHealth;
        }

        private void Update()
        {
            restoreTimer += Time.deltaTime;

            if (restoreTimer >= m_restoreDelay)
            {
                RestoreHealth(m_restoreHealthAmount);
                restoreTimer = 0;
            }
        }

        private void RestoreHealth(float value)
        {
            if (m_currentValue == m_maxValue || value == 0) return;

            m_currentValue += value;

            if (m_currentValue > m_maxValue)
            {
                m_currentValue = m_maxValue;
            }

            InvokeChangedEvent();
        }
    }
}
