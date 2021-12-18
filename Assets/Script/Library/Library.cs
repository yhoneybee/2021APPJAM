using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Library : Singletone<Library>
{
    [SerializeField] private Canvas canvas;
    [SerializeField] private List<BookDrop> bookDrops;
    [SerializeField] private Book originBook;

    private List<Book> books;

    private void Start()
    {
        Global.camera = Camera.main;
        Global.canvas = canvas;
        books = new List<Book>();

        for (int i = 0; i < bookDrops.Count; i++)
        {
            var book = Instantiate(originBook, Global.canvas.transform, false);
            book.rtrn.anchoredPosition = bookDrops[i].GetComponent<RectTransform>().anchoredPosition;
            int h = Random.Range(1, 10);
            book.code = h * 100;
            book.code += Random.Range(0, 100);
            book.charCode = ((char)Random.Range(65, 65 + 27));
            books.Add(book);
        }
    }

    private void Update()
    {

    }

    public void CheckSort()
    {
        var sort = books.OrderBy(x => x.charCode).OrderBy(x => x.code).ToList();
        bool result = false;
        for (int i = 0; i < sort.Count; i++)
        {
            result = sort[i].sortIndex == i;
            if (!result) break;
        }

        if (result) print("Clear");
    }
}
