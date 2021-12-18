using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleManager : Singletone<TitleManager>
{
    [SerializeField] private Canvas canvas;
    private void Start()
    {
        Global.camera = Camera.main;
        Global.Canvas = canvas;

        SoundManager.Instance.Play("Bgm", SoundType.BGM);
    }
}
