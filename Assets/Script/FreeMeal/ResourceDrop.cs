using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ResourceDrop : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        FreeMeal.Instance.resources.Add(Resource.resource.resourceType);
        if (FreeMeal.Instance.CheckResource())
        {
            FreeMeal.Instance.resources.Clear();
            FreeMeal.Instance.LeftCount--;
        }
    }
}
