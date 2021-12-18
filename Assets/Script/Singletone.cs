using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Singletone<T> : MonoBehaviour
{
    public static T Instance { get; protected set; }

    private void Awake()
    {
        Instance = GetComponent<T>();
    }
}
