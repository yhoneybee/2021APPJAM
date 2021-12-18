using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public struct WinSetting
{
    public GameObject go;
    public Image imgFade;
    public Image imgBg;
    public Button btnClose;
    public Toggle[] arrTogSound;
    public Slider[] arrSliderSound;
}

public class Setting : MonoBehaviour
{
    public Image imgFade;
    public Image imgBg;
    public Button btnClose;
    public Toggle[] arrTogSound;
    public Slider[] arrSliderSound;

    private void Start()
    {
        Global.winSetting.go = gameObject;
        Global.winSetting.imgFade = imgFade;
        Global.winSetting.imgBg = imgBg;
        Global.winSetting.btnClose = btnClose;
        Global.winSetting.arrTogSound = arrTogSound;
        Global.winSetting.arrSliderSound = arrSliderSound;
        gameObject.SetActive(false);
        Global.winSetting.btnClose.onClick.AddListener(() => 
        { 
            StartCoroutine(Global.EFill(Global.winSetting.imgBg, 0));
        });
    }

    private void OnEnable()
    {
        if (Global.winSetting.imgBg)
        {
            Global.winSetting.imgBg.fillAmount = 0;
            StartCoroutine(Global.EFill(Global.winSetting.imgBg, 1));
        }
    }
}
