using UnityEngine;
using UnityEngine.Events;

namespace CodeBase.Gameplay
{
    public class Health : MonoBehaviour
    {
        public event UnityAction EventOnChanged;
        public event UnityAction EventOnDie;

        [SerializeField] protected float m_maxValue;
        [SerializeField] protected float m_currentValue;

        public float MaxValue => m_maxValue;
        public float CurrentValue => m_currentValue;

        public void ApplyDamage(float damage)
        {
            if (m_currentValue == 0 || damage == 0) return;

            m_currentValue -= damage;

            if (m_currentValue <=0)
            {
                m_currentValue = 0;
                EventOnDie?.Invoke();
            }

            InvokeChangedEvent();
        }

        protected void InvokeChangedEvent()
        {
            EventOnChanged?.Invoke();
        }
    }
}
