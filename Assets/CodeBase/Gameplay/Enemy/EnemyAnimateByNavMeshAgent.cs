using UnityEngine;
using UnityEngine.AI;

namespace CodeBase.Gameplay.Enemy
{
    public class EnemyAnimateByNavMeshAgent : MonoBehaviour
    {
        private const float _Threshold = 0.05f;

        [SerializeField] private NavMeshAgent m_agent;
        [SerializeField] private EnemyAnimator m_animator;

        private void Update()
        {
            m_animator.SetMove(m_agent.velocity.magnitude >= _Threshold);
        }
    }
}
