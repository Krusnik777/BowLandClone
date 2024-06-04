using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField] private Transform m_target;

    public void SetTarget(Transform target) => m_target = target;

    private void LateUpdate()
    {
        if (m_target == null) return;

        transform.position = m_target.position;
    }
}
