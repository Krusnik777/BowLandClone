using CodeBase.Infrastructure.EntryPoints;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace CodeBase.Bootstrappers
{
    public class GameBootstrapper : MonoBootstrapper
    {
        public override void Bootstrap()
        {
            Debug.Log("GLOBAL: Init");

            DontDestroyOnLoad(gameObject);

            Application.targetFrameRate = (int)Screen.currentResolution.refreshRateRatio.value;

            SceneManager.LoadScene("Level_1"); // TEMP
        }
    }
}
