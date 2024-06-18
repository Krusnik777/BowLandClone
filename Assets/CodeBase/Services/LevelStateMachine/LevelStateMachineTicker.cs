using CodeBase.Infrastructure.DependencyInjection;
using UnityEngine;

namespace CodeBase.Services.LevelStateMachine
{
    public class LevelStateMachineTicker : MonoBehaviour, IService
    {
        private ILevelStateSwitcher levelStateSwitcher;

        [Inject]
        public void Construct(ILevelStateSwitcher levelStateSwitcher)
        {
            this.levelStateSwitcher = levelStateSwitcher;
        }

        private void Update()
        {
            levelStateSwitcher.UpdateTick();
        }
    }
}
