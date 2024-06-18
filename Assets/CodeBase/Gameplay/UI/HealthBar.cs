using UnityEngine;
using UnityEngine.UI;

namespace CodeBase.Gameplay.UI
{
    public class HealthBar : MonoBehaviour
    {
        [SerializeField] private Health m_health;
        [SerializeField] private Image m_image;

        private void Start()
        {
            m_health.EventOnChanged += OnHitPointsChanged;

            OnHitPointsChanged();
        }

        private void OnDestroy()
        {
            m_health.EventOnChanged -= OnHitPointsChanged;
        }

        private void OnHitPointsChanged()
        {
            m_image.fillAmount = m_health.CurrentValue / m_health.MaxValue;
        }
    }
}
