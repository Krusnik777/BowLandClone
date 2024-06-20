using CodeBase.Data;
using CodeBase.Services;
using UnityEngine;

namespace CodeBase.Gameplay.Hero
{
    public class HeroMovement : MonoBehaviour, IProgressLoadHandler
    {
        [SerializeField] private CharacterController m_characterController;
        [SerializeField] private Transform m_viewTransform;
        [SerializeField] private float m_movementSpeed;

        private Vector3 directionControl;
        public Vector3 DirectionControl => directionControl;

        public void Load(PlayerProgress playerProgress)
        {
            m_movementSpeed = playerProgress.HeroStats.MovementSpeed;
        }

        public void SetMoveDirection(Vector2 moveDirection)
        {
            directionControl.x = moveDirection.x;
            directionControl.z = moveDirection.y;
            directionControl.Normalize();
        }

        private void Update()
        {
            if (directionControl.magnitude > 0)
            {
                m_characterController.Move(directionControl * m_movementSpeed * Time.deltaTime);
                m_viewTransform.rotation = Quaternion.LookRotation(directionControl);
            }
            else
            {
                m_characterController.Move(Vector3.zero);
            }
        }
    }
}
