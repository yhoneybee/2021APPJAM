using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TitleManager : Singletone<TitleManager>
{
    [SerializeField] private Canvas canvas;
    [SerializeField] private Button btnStart;
    [SerializeField] private Button btnCredit;
    [SerializeField] private Button btnExit;
    [SerializeField] private Animator anim;
    private bool appear;
    private void Start()
    {
        Global.camera = Camera.main;
        Global.Canvas = canvas;

        SoundManager.Instance.Play("Bgm", SoundType.BGM);

        btnStart.onClick.AddListener(() => { Global.SceneMove("Map"); });

        Global.winSetting.btnMap.gameObject.SetActive(false);

        btnCredit.onClick.AddListener(() => 
        {
            anim.Play("Appear");
            appear = true;
        });

        btnExit.onClick.AddListener(() => 
        {
            Application.Quit();
        });
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && appear)
        {
            if (!EventSystem.current.IsPointerOverGameObject())
            {
                anim.Play("Disappear");
                appear = false;
            }
        }
    }
}
