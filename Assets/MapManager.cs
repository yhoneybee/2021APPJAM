using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
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
