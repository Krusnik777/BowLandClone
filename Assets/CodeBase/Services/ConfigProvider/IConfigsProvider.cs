using CodeBase.Configs;
using CodeBase.Gameplay.Enemy;
using CodeBase.Infrastructure.DependencyInjection;
using CodeBase.UI.Windows;

namespace CodeBase.Services.ConfigsProvider
{
    public interface IConfigsProvider : IService
    {
        int LevelsAmount { get; }

        EnemyConfig GetConfig(EnemyId enemyId);
        WindowConfig GetConfig(WindowId windowId);
        LevelConfig GetLevel(int index);
        LevelConfig GetLevel(string name);
        void Load();
    }
}