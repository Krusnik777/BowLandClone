using CodeBase.Data;
using CodeBase.Services.ProgressProvider;
using System.Collections.Generic;
using UnityEngine;

namespace CodeBase.Services.ProgressSaver
{
    public class ProgressSaver : IProgressSaver
    {
        private const string ProgressKey = "Progress";

        private IProgressProvider progressProvider;

        private List<IProgressBeforeSaveHandler> progressBeforeSaveHandlers;
        private List<IProgressLoadHandler> progressLoadHandlers;

        public ProgressSaver(IProgressProvider progressProvider)
        {
            this.progressProvider = progressProvider;

            progressBeforeSaveHandlers = new List<IProgressBeforeSaveHandler>();
            progressLoadHandlers = new List<IProgressLoadHandler>();
        }

        public void AddObject(GameObject gameObject)
        {
            foreach (IProgressLoadHandler progressLoadHandler in gameObject.GetComponentsInChildren<IProgressLoadHandler>())
            {
                if (!progressLoadHandlers.Contains(progressLoadHandler))
                    progressLoadHandlers.Add(progressLoadHandler);
            }

            foreach (IProgressBeforeSaveHandler progressBeforeSaveHandler in gameObject.GetComponentsInChildren<IProgressBeforeSaveHandler>())
            {
                if (!progressBeforeSaveHandlers.Contains(progressBeforeSaveHandler))
                    progressBeforeSaveHandlers.Add(progressBeforeSaveHandler);
            }
        }

        public void ClearObjects()
        {
            progressBeforeSaveHandlers.Clear();
            progressLoadHandlers.Clear();
        }

        public void LoadProgress()
        {
            if (!PlayerPrefs.HasKey(ProgressKey))
            {
                progressProvider.PlayerProgress = PlayerProgress.GetDefaultProgress();
            }
            else
            {
                progressProvider.PlayerProgress = JsonUtility.FromJson<PlayerProgress>(PlayerPrefs.GetString(ProgressKey));
            }

            foreach (IProgressLoadHandler progressLoadHandler in progressLoadHandlers)
            {
                progressLoadHandler?.Load(progressProvider.PlayerProgress);
                Debug.Log("Collected Coins: " + progressProvider.PlayerProgress.HeroWallet.Coins);
            }
        }

        public void SaveProgress()
        {
            foreach (IProgressBeforeSaveHandler progressBeforeSaveHandler in progressBeforeSaveHandlers)
            {
                progressBeforeSaveHandler?.UpdateProgressBeforeSave(progressProvider.PlayerProgress);
            }

            PlayerPrefs.SetString(ProgressKey, JsonUtility.ToJson(progressProvider.PlayerProgress));
        }
    }
}
