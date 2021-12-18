using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fade : MonoBehaviour
{
    public Image img;
    public Animator anim;
    public System.Action action;
    private void Start()
    {
        action = () => { };
        Global.fade = this;
        anim.Play("Disappear");
        SoundManager.Instance.audioSources[0].Stop();
    }

    public void AppearSuccess()
    {
        action();
    }
}
