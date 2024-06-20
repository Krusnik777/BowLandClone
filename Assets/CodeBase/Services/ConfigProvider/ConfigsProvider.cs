using CodeBase.Configs;
using CodeBase.Gameplay.Enemy;
using CodeBase.UI.Windows;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace CodeBase.Services
{
    public class ConfigsProvider : IConfigsProvider
    {
        private const string _EnemiesConfigPath = "Configs/Enemies";
        private const string _LevelsConfigPath = "Configs/Levels";
        private const string _WindowsConfigPath = "Configs/Windows";

        private Dictionary<EnemyId, EnemyConfig> enemies;
        private Dictionary<string, LevelConfig> levels;
        private Dictionary<WindowId, WindowConfig> windows;

        private LevelConfig[] levelList;

        public int LevelsAmount => levelList.Length;

        public EnemyConfig GetEnemy(EnemyId enemyId)
        {
            if (!enemies.ContainsKey(enemyId)) return null;

            return enemies[enemyId];
        }

        public WindowConfig GetWindow(WindowId windowId)
        {
            if (!windows.ContainsKey(windowId)) return null;

            return windows[windowId];
        }

        public LevelConfig GetLevel(int index)
        {
            if (index >= levelList.Length || index < 0) return null;

            return levelList[index];
        }

        public LevelConfig GetLevel(string name)
        {
            if (!levels.ContainsKey(name)) return null;

            return levels[name];
        }

        public EnemyConfig[] GetAllEnemies()
        {
            return enemies.Values.ToArray();
        }

        public void Load()
        {
            enemies = Resources.LoadAll<EnemyConfig>(_EnemiesConfigPath).ToDictionary(x => x.EnemyId, x => x);
            windows = Resources.LoadAll<WindowConfig>(_WindowsConfigPath).ToDictionary(x => x.WindowId, x => x);

            levelList = Resources.LoadAll<LevelConfig>(_LevelsConfigPath);
            levels = levelList.ToDictionary(x => x.SceneName, x => x);
        }
    }
}
