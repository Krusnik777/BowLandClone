using CodeBase.Infrastructure.DependencyInjection;
using CodeBase.Services;
using UnityEngine;
using UnityEngine.UI;

namespace CodeBase.UI.Elements
{
    public class RewardedAdsItem : MonoBehaviour
    {
        [SerializeField] private Button m_showAdsButton;
        [SerializeField] private int m_rewardAmount;

        private IAdsService adsService;
        private IProgressProvider progressProvider;
        private IProgressSaver progressSaver;

        [Inject]
        public void Construct(IAdsService adsService, IProgressProvider progressProvider, IProgressSaver progressSaver)
        {
            this.adsService = adsService;
            this.progressProvider = progressProvider;
            this.progressSaver = progressSaver;
        }

        private void Start()
        {
            m_showAdsButton.onClick.AddListener(OnShowAdsButtonClicked);
            m_showAdsButton.gameObject.SetActive(false);
        }

        private void OnDestroy()
        {
            m_showAdsButton.onClick.RemoveListener(OnShowAdsButtonClicked);
        }

        private void Update()
        {
            if (adsService == null) return;

            bool isVideoAvailable = adsService.IsRewardedVideoReady && 
                (Application.internetReachability == NetworkReachability.ReachableViaLocalAreaNetwork || Application.internetReachability == NetworkReachability.ReachableViaCarrierDataNetwork);
            m_showAdsButton.gameObject.SetActive(isVideoAvailable);
        }

        private void OnShowAdsButtonClicked()
        {
            adsService.ShowRewarded(() =>
            {
                progressProvider.PlayerProgress.HeroWallet.AddCoins(m_rewardAmount);
                progressSaver.SaveProgress();
            });
        }
    }
}
