using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuralManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SoundManager.Instance.Play("WallDraw", SoundType.BGM);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Clear()
    {
        Global.SceneMove("Map", true);
    }
}
