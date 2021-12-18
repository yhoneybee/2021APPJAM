using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class BookDrop : MonoBehaviour, IDropHandler
{
    [SerializeField] private int sortIndex;

    public void OnDrop(PointerEventData eventData)
    {
        Book.selectBook.rtrn.position = GetComponent<RectTransform>().position;
        Book.selectBook.sortIndex = sortIndex;
        Book.selectBook = null;
        Library.Instance.CheckSort();
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
