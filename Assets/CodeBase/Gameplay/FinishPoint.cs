using UnityEngine;

namespace CodeBase.Gameplay
{
    public class FinishPoint : MonoBehaviour
    {
        public static float Radius = 3;

        #if UNITY_EDITOR

        private void OnDrawGizmos()
        {
            Gizmos.color = new Color(0.785f, 0.4f, 0, 0.7f);
            Gizmos.DrawSphere(transform.position, Radius);
        }

        #endif
    }
}
