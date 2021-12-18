using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ResourceDrop : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        Resource.resource.rtrn.SetParent(gameObject.transform);
        FreeMeal.Instance.resources.Add(Resource.resource);
        if (FreeMeal.Instance.CheckResource())
        {
            foreach (var item in FreeMeal.Instance.resources)
            {
                item.rtrn.SetParent(null);
                Destroy(item.gameObject);
            }
            FreeMeal.Instance.resources.Clear();
            FreeMeal.Instance.LeftCount--;
        }
    }
}
