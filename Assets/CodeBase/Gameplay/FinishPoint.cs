using CodeBase.Infrastructure.DependencyInjection;
using UnityEngine;

namespace CodeBase.Gameplay
{
    public class FinishPoint : MonoBehaviour, IService
    {
        [SerializeField] private float m_radius = 3;
        public float Radius => m_radius;

        #if UNITY_EDITOR

        private void OnDrawGizmos()
        {
            Gizmos.color = new Color(0.785f, 0.4f, 0, 0.7f);
            Gizmos.DrawSphere(transform.position, m_radius);
        }

        #endif
    }
}
