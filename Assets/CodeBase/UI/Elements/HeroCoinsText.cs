using CodeBase.Infrastructure.DependencyInjection;
using CodeBase.Services.ProgressProvider;
using UnityEngine;
using UnityEngine.UI;

namespace CodeBase.UI.Elements
{
    public class HeroCoinsText : MonoBehaviour
    {
        [SerializeField] private Text m_text;

        private IProgressProvider progressProvider;

        [Inject]
        public void Construct(IProgressProvider progressProvider)
        {
            this.progressProvider = progressProvider;
        }

        private void Start()
        {
            progressProvider.PlayerProgress.HeroWallet.EventOnCoinsValueChanged += OnCoinsValueChanged;

            OnCoinsValueChanged(progressProvider.PlayerProgress.HeroWallet.Coins);
        }

        private void OnDestroy()
        {
            progressProvider.PlayerProgress.HeroWallet.EventOnCoinsValueChanged -= OnCoinsValueChanged;
        }

        private void OnCoinsValueChanged(int coinsValue)
        {
            m_text.text = coinsValue.ToString();
        }
    }
}
