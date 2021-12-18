using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public enum eRESOURCE_TYPE
{
    Bread,
    Jam,
    Egg,
    Mayo,
    Cat,
    Ham,
    Yang,
    Gamja,
}

public class ResourceDrag : MonoBehaviour, IDragHandler, IPointerDownHandler, IEndDragHandler
{
    public eRESOURCE_TYPE resourceType;
    public Sprite sprite;

    public void OnDrag(PointerEventData eventData)
    {
        Resource.resource.rtrn.anchoredPosition = eventData.position - new Vector2(Screen.width / 2, Screen.height / 2);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Destroy(Resource.resource.gameObject);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        var obj = Instantiate(FreeMeal.Instance.resource, FreeMeal.Instance.rtrnResourceParent, false);
        obj.img.sprite = sprite;
        obj.resourceType = resourceType;
        obj.rtrn.anchoredPosition = eventData.position - new Vector2(Screen.width / 2, Screen.height / 2);
        obj.img.raycastTarget = false;
        Resource.resource = obj;
    }
}
