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
    public Button btnMap;
    public Toggle[] arrTogSound;
    public Slider[] arrSliderSound;
}

public class Setting : MonoBehaviour
{
    public Image imgFade;
    public Image imgBg;
    public Button btnClose;
    public Button btnMap;
    public Toggle[] arrTogSound;
    public Slider[] arrSliderSound;

    private void Start()
    {
        Global.winSetting.go = gameObject;
        Global.winSetting.imgFade = imgFade;
        Global.winSetting.imgBg = imgBg;
        Global.winSetting.btnClose = btnClose;
        Global.winSetting.btnMap = btnMap;
        Global.winSetting.arrTogSound = arrTogSound;
        Global.winSetting.arrSliderSound = arrSliderSound;
        gameObject.SetActive(false);
        Global.winSetting.btnClose.onClick.AddListener(() =>
        {
            StartCoroutine(Global.EFill(Global.winSetting.imgBg, 0));
        });
        Global.winSetting.arrTogSound[0].onValueChanged.AddListener((b) =>
        {
            Global.winSetting.arrTogSound[0].transform.GetChild(0).GetChild(b ? 1 : 0).gameObject.SetActive(true);
            Global.winSetting.arrTogSound[0].transform.GetChild(0).GetChild(b ? 0 : 1).gameObject.SetActive(false);
        });

        Global.winSetting.arrTogSound[1].onValueChanged.AddListener((b) =>
        {
            Global.winSetting.arrTogSound[1].transform.GetChild(0).GetChild(b ? 1 : 0).gameObject.SetActive(true);
            Global.winSetting.arrTogSound[1].transform.GetChild(0).GetChild(b ? 0 : 1).gameObject.SetActive(false);
        });

        Global.winSetting.btnMap.onClick.AddListener(() => 
        {
            SoundManager.Instance.audioSources[((int)SoundType.BGM)].UnPause();
            Global.SceneMove("Map");
        });
    }

    private void OnEnable()
    {
        if (Global.winSetting.imgBg)
        {
            Global.winSetting.imgBg.fillAmount = 0;
            StartCoroutine(Global.EFill(Global.winSetting.imgBg, 1));
            Global.timeScale = 0;
            SoundManager.Instance.audioSources[((int)SoundType.BGM)].Pause();
        }
    }
}
