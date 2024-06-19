using CodeBase.Configs;
using UnityEngine;

namespace CodeBase.Gameplay.Enemy
{
    public class EnemyHealth : Health, IEnemyConfigInstaller
    {
        public void InstallConfig(EnemyConfig config)
        {
            m_currentValue = config.MaxHealth;
            m_maxValue = config.MaxHealth;
        }
    }
}
