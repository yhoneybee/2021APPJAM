using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Coal : Singletone<Coal>
{
    public List<Human> humans = new List<Human>();
    public RectTransform rtrnCoalParent;
    public CoalObj originCoal;
    public int GiveCoalCount
    {
        get => giveCoalCount;
        set
        {
            giveCoalCount = value;
            txtScore.text = $"Give Coal Count : {giveCoalCount}\nTarget Count : 100";
            if (GiveCoalCount >= 100)
            {
                print("Clear");
            }
        }
    }
    [SerializeField] private Canvas canvas;
    [SerializeField] private int giveCoalCount = 0;
    [SerializeField] private TextMeshProUGUI txtScore;

    void Start()
    {
        Global.camera = Camera.main;
        Global.Canvas = canvas;

        GiveCoalCount = 0;
    }

    void Update()
    {

    }
}
