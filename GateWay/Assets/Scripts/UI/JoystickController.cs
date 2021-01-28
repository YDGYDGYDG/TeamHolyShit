using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class JoystickController : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler

{
    [SerializeField]

    RectTransform lever;
    RectTransform rectTransform;


    [SerializeField, Range(10f, 150f)]
    private float leverRange;

    public GameObject HookOffBtn;

    HookShotScript player;

    Vector2 clampedDir;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        player = GameObject.Find("player").GetComponent<HookShotScript>();
    }


    public void OnBeginDrag(PointerEventData eventData)

    {
        DragControl(eventData);
    }


    public void OnDrag(PointerEventData eventData)
    {
        DragControl(eventData);
        player.HookAim();
    }


    public void OnEndDrag(PointerEventData eventData)
    {
        lever.anchoredPosition = Vector2.zero;
        player.shootDir = clampedDir.normalized;
        if (!player.isHaveShootableObject)
        {
            player.HookShot();
            HookOffBtn.SetActive(true);
        }
        else
        {
            player.ShootObject();
        }
    }

    void DragControl(PointerEventData eventData)
    {
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(
            rectTransform, eventData.position, eventData.pressEventCamera, out Vector2 localPoint)
            )
        {
            clampedDir = localPoint.magnitude < leverRange ? localPoint : localPoint.normalized * leverRange;
            lever.anchoredPosition = clampedDir;
            player.aimDir = (lever.position - rectTransform.position).normalized;
        }
    }

}



