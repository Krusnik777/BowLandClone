using CodeBase.Infrastructure.DependencyInjection;
using CodeBase.Services;
using UnityEngine;

namespace CodeBase.Gameplay.Hero
{
    public class HeroInput : MonoBehaviour
    {
        [SerializeField] private HeroMovement m_heroMovement;

        private IInputService inputService;

        [Inject]
        public void Construct(IInputService inputService)
        {
            this.inputService = inputService;
        }

        /*
        private void Start()
        {
            inputService = AllServices.Container.Single<IInputService>();
        }*/

        private void Update()
        {
            if (inputService == null) return;

            m_heroMovement.SetMoveDirection(inputService.MovementAxis);
        }
    }
}