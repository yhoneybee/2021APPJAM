using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    [SerializeField] private Canvas canvas;
    // Start is called before the first frame update
    void Start()
    {
        Global.camera = Camera.main;
        Global.Canvas = canvas;
        SoundManager.Instance.Play("Bgm", SoundType.BGM);
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Global.SceneMove("Ending", false);
        }
    }
}
