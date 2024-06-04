using UnityEngine;
using UnityEngine.EventSystems;

public class VirtualJoystick : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
{
    [SerializeField] private RectTransform m_stickArea;
    [SerializeField] private RectTransform m_stick;

    public static Vector2 Value { get; private set; }

    public void OnPointerDown(PointerEventData eventData)
    {
        Move(eventData.position);
    }

    public void OnDrag(PointerEventData eventData)
    {
        Move(eventData.position);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        m_stick.anchoredPosition = Vector3.zero;
        Value = Vector2.zero;
    }

    private void Move(Vector2 newPos)
    {
        m_stick.position = newPos;

        if (m_stick.anchoredPosition.magnitude > m_stickArea.sizeDelta.x / 2)
        {
            m_stick.anchoredPosition = m_stick.anchoredPosition.normalized * (m_stickArea.sizeDelta.x / 2);
        }

        Value = new Vector2(m_stick.anchoredPosition.x, m_stick.anchoredPosition.y).normalized;
    }
}
