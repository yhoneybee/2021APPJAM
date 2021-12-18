using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Fade : MonoBehaviour
{
    public Image img;
    public Animator anim;
    public System.Action action;
    private void Start()
    {
        action = () => { };
        Global.fade = this;
        anim.Play("Disappear");
        if (Global.SceneCheck("Map") || Global.SceneCheck("Ending"))
        {
            Global.winSetting.btnMap.onClick.RemoveAllListeners();
            Global.winSetting.btnMap.onClick.AddListener(() => { Global.SceneMove("Title"); });
            Global.winSetting.btnMap.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Back To Title";
        }
    }

    public void AppearSuccess()
    {
        action();
    }
}
