using CodeBase.Infrastructure.DependencyInjection;
using UnityEngine;

namespace CodeBase.Services
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

            //Debug.Log(levelStateSwitcher.CurrentState.ToString());
        }
    }
}
