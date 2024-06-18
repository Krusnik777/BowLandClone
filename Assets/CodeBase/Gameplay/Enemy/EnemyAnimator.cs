using UnityEngine;

namespace CodeBase.Gameplay.Enemy
{
    public class EnemyAnimator : MonoBehaviour
    {
        private const string _IsMoving = "IsMoving";
        private const string _AttackTrigger = "Attack";

        [SerializeField] private Animator m_animator;

        public void PlayAttack()
        {
            m_animator.SetTrigger(_AttackTrigger);
        }

        public void SetMove(bool move)
        {
            m_animator.SetBool(_IsMoving, move);
        }
    }
}
