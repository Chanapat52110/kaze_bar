using UnityEngine;
using UnityEngine.EventSystems;

public class HoldArea : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public ShakerController shaker;

    public void OnPointerDown(PointerEventData eventData) => shaker?.OnHoldDown();
    public void OnPointerUp(PointerEventData eventData)   => shaker?.OnHoldUp();
}
