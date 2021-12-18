using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Massage : Singletone<Massage>
{
    [SerializeField] private Canvas canvas;
    [SerializeField] private Animator anim;
    [SerializeField] private BubbleText bubbleText;
    [SerializeField] private List<string> txts;
    [SerializeField] private int massageCount;
    private int target;
    private int input;

    void Start()
    {
        Global.camera = Camera.main;
        Global.Canvas = canvas;

        anim.Play("Appear");
        StartCoroutine(EBubbleText());
    }

    void Update()
    {
        input = 0;
        if (GetKeys(KeyCode.Q, KeyCode.W, KeyCode.E, KeyCode.R))
        {
            print("<color=red>Left Up</color>");
            input = 11;
        }
        if (GetKeys(KeyCode.A, KeyCode.S, KeyCode.D, KeyCode.F))
        {
            print("<color=orange>Left Middle</color>");
            input = 12;
        }
        if (GetKeys(KeyCode.Z, KeyCode.X, KeyCode.C, KeyCode.V))
        {
            print("<color=yellow>Left Down</color>");
            input = 13;
        }

        if (GetKeys(KeyCode.U, KeyCode.I, KeyCode.O, KeyCode.P))
        {
            print("<color=red>Right Up</color>");
            input = 21;
        }
        if (GetKeys(KeyCode.J, KeyCode.K, KeyCode.L, KeyCode.Semicolon))
        {
            print("<color=orange>Right Middle</color>");
            input = 22;
        }
        if (GetKeys(KeyCode.M, KeyCode.Comma, KeyCode.Period, KeyCode.Slash))
        {
            print("<color=yellow>Right Down</color>");
            input = 23;
        }

        if (target != 0 && input != 0 && target == input)
            bubbleText.Text = "";
        if (target != 0 && input != 0 && target == input && massageCount > 0)
        {
            massageCount--;
            StartCoroutine(EBubbleText());
        }
        if (massageCount == 0)
        {
            Global.SceneMove("Map", true);
        }
    }

    public bool GetKeys(params KeyCode[] keys)
    {
        bool result = false;
        for (int i = 0; i < keys.Length; i++) result = Input.GetKey(keys[i]);
        return result;
    }

    private IEnumerator EBubbleText()
    {
        var wait = new WaitForSeconds(3 * Global.timeScale);
        target = 0;
        yield return wait;
        string strChange = txts[Random.Range(0, txts.Count)];
        string value1 = "", value2 = "";
        switch (Random.Range(0, 2))
        {
            case 0:
                value1 = "왼쪽";
                target += 10;
                break;
            case 1:
                value1 = "오른쪽";
                target += 20;
                break;
        }

        switch (Random.Range(0, 3))
        {
            case 0:
                value2 = "위쪽";
                target += 1;
                break;
            case 1:
                value2 = "중간쪽";
                target += 2;
                break;
            case 2:
                value2 = "아래쪽";
                target += 3;
                break;
        }
        strChange = strChange.Replace("value1", value1);
        strChange = strChange.Replace("value2", value2);
        bubbleText.Text = strChange;
        yield return null;
    }
}
