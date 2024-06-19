using CodeBase.Gameplay;
using UnityEngine;
using UnityEngine.UI;

namespace CodeBase.UI.Elements
{
    public class HealthText : MonoBehaviour
    {
        [SerializeField] private Health m_health;
        [SerializeField] private Text m_text;

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
            m_text.text = m_health.CurrentValue.ToString();
        }
    }
}
