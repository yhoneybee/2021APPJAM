using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    [SerializeField] private RectTransform rtrn;
    [SerializeField] private float speed;
    void Update()
    {
        transform.Translate(Vector3.down * Time.deltaTime * speed * Global.timeScale);
        if (rtrn.anchoredPosition.y <= -400)
        {
            FreeShow.Instance.SpawnTxtResult(0);
            Destroy(gameObject);
        }
    }
}
