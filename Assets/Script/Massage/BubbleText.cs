using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BubbleText : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI txt;
    [SerializeField] private Animator anim;
    public string Text
    {
        get => text;
        set
        {
            text = value;
            if (text == "")
                anim.Play("Disappear");
            else
                anim.Play("Appear");
        }
    }
    private string text;

    public void ApplyText() => txt.text = Text;
    public void ResetText() => txt.text = "";
}
