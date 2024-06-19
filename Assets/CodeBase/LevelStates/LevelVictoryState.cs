using CodeBase.GameStates;
using CodeBase.Infrastructure.DependencyInjection;
using CodeBase.Infrastructure.StateMachine;
using CodeBase.Services.GameFactory;
using CodeBase.Services.GameStateMachine;
using CodeBase.Services.Input;
using CodeBase.Services.ProgressProvider;
using CodeBase.Services.ProgressSaver;
using CodeBase.UI.Services.WindowsProvider;

namespace CodeBase.LevelStates
{
    public class LevelVictoryState : IEnterableState, IService
    {
        private IInputService inputService;
        private IGameFactory gameFactory;
        private IProgressProvider progressProvider;
        private IProgressSaver progressSaver;
        private IWindowsProvider windowsProvider;

        public LevelVictoryState(IInputService inputService, IGameFactory gameFactory, IProgressProvider progressProvider,
            IProgressSaver progressSaver, IWindowsProvider windowsProvider)
        {
            this.inputService = inputService;
            this.gameFactory = gameFactory;
            this.progressProvider = progressProvider;
            this.progressSaver = progressSaver;
            this.windowsProvider = windowsProvider;
        }

        public void Enter()
        {
            inputService.Enabled = false;
            gameFactory.VirtualJoystick.gameObject.SetActive(false);

            progressProvider.PlayerProgress.HeroStats.Damage += 2;
            progressProvider.PlayerProgress.HeroStats.MaxHealth += 5;
            progressProvider.PlayerProgress.HeroStats.MovementSpeed += 0.1f;
            progressProvider.PlayerProgress.CurrentLevelIndex++;

            windowsProvider.Open(UI.Windows.WindowId.VictoryWindow);

            progressSaver.SaveProgress();
        }
    }
}
