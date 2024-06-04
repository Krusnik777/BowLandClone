using UnityEngine;

namespace CodeBase.Gameplay.Hero
{
    public class HeroAnimator : MonoBehaviour
    {
        private const string _IsMoving = "IsMoving";
        private const string _AttackTrigger = "Attack";
        private const float _MovementThreshold = 0.05f;

        [SerializeField] private CharacterController m_characterController;
        [SerializeField] private Animator m_animator;

        public void Attack()
        {
            m_animator.SetTrigger(_AttackTrigger);
        }

        private void Update()
        {
            m_animator.SetBool(_IsMoving, m_characterController.velocity.magnitude >= _MovementThreshold);
        }
    }
}