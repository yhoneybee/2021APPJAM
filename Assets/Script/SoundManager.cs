using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public enum SoundType
{
    BGM,
    EFFECT,
    BUTTON,
    END,
}

public class SoundManager : Singletone<SoundManager>
{

    public AudioSource[] audioSources = new AudioSource[(int)SoundType.END];

    Dictionary<string, AudioClip> audioClips = new Dictionary<string, AudioClip>();

    private float bgm_volume = 0.5f;
    public float BgmVolume
    {
        get { return bgm_volume * TotalVolume; }
        set { bgm_volume = value; audioSources[((int)SoundType.BGM)].volume = BgmVolume; }
    }
    private float sfx_volume = 0.5f;
    public float SfxVolume
    {
        get { return sfx_volume * TotalVolume; }
        set 
        { 
            sfx_volume = value;
            audioSources[((int)SoundType.EFFECT)].volume = SfxVolume;
            audioSources[((int)SoundType.BUTTON)].volume = SfxVolume;
        }
    }

    private float total_volume;
    public float TotalVolume
    {
        get { return total_volume; }
        set
        {
            total_volume = value;

            audioSources[((int)SoundType.BGM)].volume = BgmVolume;
            audioSources[((int)SoundType.EFFECT)].volume = SfxVolume;
        }
    }

    protected override void Awake()
    {
        base.Awake();
        GameObject sound = GameObject.Find("SoundManager");

        if (sound)
        {
            name = "SoundManager";
            DontDestroyOnLoad(gameObject);

            string[] soundNames = Enum.GetNames(typeof(SoundType));

            for (int i = 0; i < soundNames.Length - 1; i++)
            {
                GameObject go = new GameObject { name = soundNames[i] };
                audioSources[i] = go.AddComponent<AudioSource>();
                go.transform.SetParent(sound.transform);
            }

            audioSources[(int)SoundType.BGM].loop = true;
        }
    }
    private void Start()
    {
        TotalVolume = 0.5f;

        Global.winSetting.arrSliderSound[0].onValueChanged.AddListener((f) => { BgmVolume = f;  });
        Global.winSetting.arrSliderSound[1].onValueChanged.AddListener((f) => { SfxVolume = f;  });

        Global.winSetting.arrTogSound[0].onValueChanged.AddListener((b) => { audioSources[0].mute = b; });
        Global.winSetting.arrTogSound[1].onValueChanged.AddListener((b) => { audioSources[1].mute = audioSources[2].mute = b; });
    }

    public void Play(AudioClip audioClip, SoundType soundType = SoundType.EFFECT)
    {
        if (!audioClip)
            return;

        AudioSource audioSource;

        if (soundType == SoundType.BGM)
        {
            audioSource = audioSources[(int)SoundType.BGM];
            if (audioSource.isPlaying)
                audioSource.Stop();

            audioSource.clip = audioClip;
            audioSource.Play();
        }
        else
        {
            audioSource = audioSources[(int)SoundType.EFFECT];
            audioSource.PlayOneShot(audioClip);
        }
    }

    public void Play(string path, SoundType soundType = SoundType.EFFECT) => Play(GetOrAddAudioClip(path, soundType), soundType);

    AudioClip GetOrAddAudioClip(string path, SoundType soundType)
    {
        if (path.Contains("Sounds/") == false)
            path = $"Sounds/{path}";

        AudioClip audioClip = null;

        if (soundType == SoundType.BGM)
        {
            audioClip = Resources.Load<AudioClip>(path);
        }
        else
        {
            if (audioClips.TryGetValue(path, out audioClip) == false)
            {
                audioClip = Resources.Load<AudioClip>(path);
                audioClips.Add(path, audioClip);
            }
        }

        if (!audioClip)
            Debug.LogWarning($"AudioClip Missing!, path info : {path}");

        return audioClip;
    }
}
