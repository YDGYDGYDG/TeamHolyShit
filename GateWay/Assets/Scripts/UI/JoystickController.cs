using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class JoystickController : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler

{
    [SerializeField]

    private RectTransform lever;
    private RectTransform rectTransform;


    [SerializeField, Range(10f, 150f)]
    private float leverRange;


    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }


    public void OnBeginDrag(PointerEventData eventData)

    {
        DragControl(eventData);
    }


    public void OnDrag(PointerEventData eventData)
    {
        DragControl(eventData);
    }


    public void OnEndDrag(PointerEventData eventData)
    {
        lever.anchoredPosition = Vector2.zero;
    }

    void DragControl(PointerEventData eventData)
    {
        if(RectTransformUtility.ScreenPointToLocalPointInRectangle(
            rectTransform, eventData.position, eventData.pressEventCamera, out Vector2 localPoint)
            )
        {
            Vector2 clampedDir = localPoint.magnitude < leverRange ? localPoint : localPoint.normalized * leverRange;
            lever.anchoredPosition = clampedDir;
        }
    }

}



