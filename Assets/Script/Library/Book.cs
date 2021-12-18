using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class Book : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
{
    public static Book selectBook;
    public RectTransform rtrn;
    [SerializeField] private TextMeshProUGUI txtCode;
    public int sortIndex;
    public int code;
    public char charCode;

    private void Start()
    {
        if (txtCode) txtCode.text = $"{code}-{charCode}";
    }

    public void OnDrag(PointerEventData eventData)
    {
        selectBook.rtrn.anchoredPosition = eventData.position - new Vector2(Screen.width / 2, Screen.height / 2);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        selectBook = this;
        sortIndex = -1;
        selectBook.GetComponent<Image>().raycastTarget = false;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        selectBook.GetComponent<Image>().raycastTarget = true;
    }
}
