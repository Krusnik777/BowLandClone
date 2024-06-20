using CodeBase.Configs;
using CodeBase.Gameplay.Enemy;
using CodeBase.Infrastructure.DependencyInjection;
using CodeBase.UI.Windows;

namespace CodeBase.Services
{
    public interface IConfigsProvider : IService
    {
        int LevelsAmount { get; }

        EnemyConfig GetEnemy(EnemyId enemyId);
        WindowConfig GetWindow(WindowId windowId);
        LevelConfig GetLevel(int index);
        LevelConfig GetLevel(string name);
        EnemyConfig[] GetAllEnemies();
        void Load();
    }
}