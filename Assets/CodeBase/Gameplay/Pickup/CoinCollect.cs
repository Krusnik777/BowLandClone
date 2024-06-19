using CodeBase.Infrastructure.DependencyInjection;
using CodeBase.Services.ProgressProvider;
using UnityEngine;

namespace CodeBase.Gameplay.Pickup
{
    public class CoinCollect : MonoBehaviour
    {
        [SerializeField] private Pickup m_pickup;
        [SerializeField] private int m_amount = 1;

        private IProgressProvider progressProvider;

        [Inject]
        public void Construct(IProgressProvider progressProvider)
        {
            this.progressProvider = progressProvider;
        }

        private void Start()
        {
            m_pickup.EventOnPicked += OnPicked;
        }

        private void OnDestroy()
        {
            m_pickup.EventOnPicked -= OnPicked;
        }

        private void OnPicked()
        {
            progressProvider.PlayerProgress.HeroWallet.AddCoins(m_amount);
        }
    }
}
