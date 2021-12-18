using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FreeMeal : Singletone<FreeMeal>
{
    [SerializeField] private Canvas canvas;
    public Resource resource;
    public RectTransform rtrnResourceParent;
    public Image imgBowl;
    public TextMeshProUGUI txtLeftCount;
    public int LeftCount
    {
        get => leftCount;
        set
        {
            leftCount = value;
            txtLeftCount.text = $"Left Count : {leftCount}";
        }
    }
    private int leftCount;
    public List<eRESOURCE_TYPE> resources;
    private List<eRESOURCE_TYPE> resourcesCompletion;

    private void Start()
    {
        Global.camera = Camera.main;
        Global.Canvas = canvas;

        LeftCount = 100;
        resources = new List<eRESOURCE_TYPE>();
        resourcesCompletion = new List<eRESOURCE_TYPE>()
        {
            eRESOURCE_TYPE.Bread,
            eRESOURCE_TYPE.Jam,
            eRESOURCE_TYPE.Egg,
            eRESOURCE_TYPE.Mayo,
            eRESOURCE_TYPE.Cat,
            eRESOURCE_TYPE.Ham,
            eRESOURCE_TYPE.Yang,
            eRESOURCE_TYPE.Gamja,
            eRESOURCE_TYPE.Bread,
        };
    }

    public bool CheckResource()
    {
        if (resources.Count != resourcesCompletion.Count) return false;
        bool result = false;
        for (int i = 0; i < resourcesCompletion.Count; i++)
        {
            result = resources[i] == resourcesCompletion[i];
            if (!result) break;
        }
        return result;
    }

    public void ClearResources()
    {
        resources.Clear();
    }
}
