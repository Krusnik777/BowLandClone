using UnityEngine.SceneManagement;

namespace CodeBase.Services.SceneLoader
{
    public class SceneLoader : ISceneLoader
    {
        public void Load(string sceneName)
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}
