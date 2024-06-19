using CodeBase.UI.Windows;
using UnityEngine;

namespace CodeBase.Configs
{
    [CreateAssetMenu(fileName = "WindowConfig", menuName = "Configs/Window")]
    public class WindowConfig : ScriptableObject
    {
        public WindowId WindowId;
        public string Title;
        public GameObject Prefab;
    }
}
