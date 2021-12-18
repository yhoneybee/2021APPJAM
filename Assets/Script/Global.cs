using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public static class Global
{
    public static Camera camera;
    public static Canvas Canvas
    {
        get => canvas;
        set
        {
            canvas = value;
            foreach (var button in canvas.GetComponentsInChildren<Button>())
            {
                button.onClick.AddListener(() =>
                {
                    SoundManager.Instance.Play("ButtonClick", SoundType.BUTTON);
                });
            }
            foreach (var toggle in canvas.GetComponentsInChildren<Toggle>())
            {
                toggle.onValueChanged.AddListener((f) =>
                {
                    SoundManager.Instance.Play("ButtonClick", SoundType.BUTTON);
                });
            }
        }
    }
    public static float timeScale = 1;
    public static WinSetting winSetting;

    private static Canvas canvas;

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
            SoundManager.Instance.audioSources[((int)SoundType.BGM)].UnPause();
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
