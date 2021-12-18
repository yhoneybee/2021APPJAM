using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreeShow : Singletone<FreeShow>
{
    [SerializeField] private Canvas canvas;

    void Start()
    {
        Global.camera = Camera.main;
        Global.canvas = canvas;
    }

    void Update()
    {
        
    }
}
