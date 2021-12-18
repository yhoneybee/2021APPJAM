using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonAlphaSet : MonoBehaviour
{
    Image img;
    // Start is called before the first frame update
    void Start()
    {

        img = GetComponent<Image>();
        img.alphaHitTestMinimumThreshold = 0.1f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
