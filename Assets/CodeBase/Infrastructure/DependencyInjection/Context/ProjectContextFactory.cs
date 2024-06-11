using UnityEngine;

namespace CodeBase.Infrastructure.DependencyInjection
{
    public class ProjectContextFactory : MonoBehaviour
    {
        private const string projectContextResourcePath = "Prefabs/ProjectContext";

        public static void TryCreate()
        {
            if (ProjectContext.Initialized) return;

            ProjectContext prefab = TryGetPrefab();

            if (prefab != null )
            {
                Instantiate(prefab);
            }
        }

        private static ProjectContext TryGetPrefab()
        {
            var prefabs = Resources.LoadAll<ProjectContext>(projectContextResourcePath);

            if (prefabs.Length > 0)
            {
                return prefabs[0];
            }

            return null;
        }
    }
}
