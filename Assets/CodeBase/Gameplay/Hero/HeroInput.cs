using CodeBase.Infrastructure.ServiceLocator;
using CodeBase.Services.Input;
using UnityEngine;

namespace CodeBase.Gameplay.Hero
{
    public class HeroInput : MonoBehaviour
    {
        [SerializeField] private HeroMovement m_heroMovement;

        private IInputService inputService;

        private void Start()
        {
            inputService = AllServices.Container.Single<IInputService>();
        }

        private void Update()
        {
            m_heroMovement.SetMoveDirection(inputService.MovementAxis);
        }
    }
}