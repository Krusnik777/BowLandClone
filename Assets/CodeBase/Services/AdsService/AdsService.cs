using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.Events;

namespace CodeBase.Services
{
    public class AdsService : IUnityAdsInitializationListener, IUnityAdsLoadListener, IUnityAdsShowListener, IAdsService
    {
        private const string _AndroidGameId = "5641855";
        private const string _IOSGameId = "5641854";
        private const string _InterstitialAndroid = "Interstitial_Android";
        private const string _InterstitialIOS = "Interstitial_iOS";
        private const string _RewardedAndroid = "Rewarded_Android";
        private const string _RewardedIOS = "Rewarded_iOS";
        private const bool _TestMode = true;

        private string interstitialId;
        private string rewardedId;
        private string gameId;
        private bool isRewardedVideoReady;

        public bool IsRewardedVideoReady => isRewardedVideoReady;

        private event UnityAction rewardedVideoCompleted;

        public void Initialize()
        {
            #if UNITY_IOS
                gameId = _iOSGameId;
                interstitialId = _InterstitialIOS;
                rewardedId = _RewardedIOS;
            #elif UNITY_ANDROID
                gameId = _AndroidGameId;
                interstitialId = _InterstitialAndroid;
                rewardedId = _RewardedAndroid;
            #elif UNITY_EDITOR
                gameId = _AndroidGameId;
                interstitialId = _InterstitialAndroid;
                rewardedId = _RewardedAndroid;
                isRewardedVideoReady = true;
            #endif

            if (!Advertisement.isInitialized && Advertisement.isSupported)
            {
                Advertisement.Initialize(gameId, _TestMode, this);
            }
        }

        public void LoadInterstital()
        {
            Advertisement.Load(interstitialId, this);
        }

        public void ShowInterstital()
        {
            Advertisement.Show(interstitialId, this);
        }

        public void LoadRewarded()
        {
            Advertisement.Load(rewardedId, this);
        }

        public void ShowRewarded(UnityAction videoCompleted)
        {
            Advertisement.Show(rewardedId, this);
            rewardedVideoCompleted = videoCompleted;
        }

        public void OnUnityAdsShowComplete(string placementId, UnityAdsShowCompletionState showCompletionState)
        {
            if (placementId == rewardedId)
            {
                if (showCompletionState == UnityAdsShowCompletionState.COMPLETED)
                {
                    rewardedVideoCompleted?.Invoke();
                }

                rewardedVideoCompleted = null;
            }
        }

        public void OnUnityAdsAdLoaded(string placementId)
        {
            Debug.Log("UnityAdsAd Loaded");

            if (placementId == rewardedId)
            {
                isRewardedVideoReady = true;
            }
        }


        public void OnInitializationComplete()
        {
            Debug.Log("Initialization Completed");
        }

        public void OnInitializationFailed(UnityAdsInitializationError error, string message)
        {
            Debug.Log(" Initialization Failed");
        }

        public void OnUnityAdsFailedToLoad(string placementId, UnityAdsLoadError error, string message)
        {
            Debug.Log("UnityAds Failed To Load");
        }

        public void OnUnityAdsShowClick(string placementId)
        {
            Debug.Log("UnityAds Show Click");
        }

        public void OnUnityAdsShowFailure(string placementId, UnityAdsShowError error, string message)
        {
            Debug.Log("UnityAds Show Failure");
        }

        public void OnUnityAdsShowStart(string placementId)
        {
            Debug.Log("UnityAds Show Start");
        }
    }
}
