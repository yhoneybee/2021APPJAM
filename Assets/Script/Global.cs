using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public static class Global
{
    public static Camera camera;
    public static Canvas canvas;
    public static float timeScale = 1;

    public static WinSetting winSetting;

    public static IEnumerator EFill(Image img, float fill)
    {
        var wait = new WaitForSeconds(0.01f);
        if (img.fillAmount > fill)
        {
            while (img.fillAmount > fill + 0.05f)
            {
                img.fillAmount = Mathf.MoveTowards(img.fillAmount, fill, Time.deltaTime * 5);
                yield return wait;
            }
            winSetting.go.SetActive(false);
            timeScale = 1;
        }
        else
        {
            while (img.fillAmount < fill - 0.05f)
            {
                img.fillAmount = Mathf.MoveTowards(img.fillAmount, fill, Time.deltaTime * 5);
                yield return wait;
            }
        }
        img.fillAmount = fill;
        yield return null;
    }
}
