using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// -400으로 가면 사라지면서 miss
public class Node : MonoBehaviour
{
    [SerializeField] private float speed;
    void Update()
    {
        transform.Translate(Vector3.down * Time.deltaTime * speed * Global.timeScale);
        if(transform.position.y <= -400) Destroy(gameObject);
    }
}
