using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PickingTrashManager : Singletone<PickingTrashManager>
{
    [SerializeField] private Canvas canvas;
    [SerializeField] private TextMeshProUGUI scoreTMP;

    public int score;
    public GameObject endingPanel;
    bool isEnding;
    float createTime;
    int nRandom;
    bool isPlay;

    // Start is called before the first frame update
    void Start()
    {
        Global.camera = Camera.main;
        Global.Canvas = canvas;

        isEnding = false;
        endingPanel.SetActive(false);
        SoundManager.Instance.Play("SanTrash", SoundType.BGM);
        score = 0;
        createTime = 3.0f;
        isPlay = true;
        StartCoroutine("CreateMaker");
    }

    // Update is called once per frame
    void Update()
    {
        nRandom = Random.Range(1, 4);
        scoreTMP.text = "score : " + $"{score}";

        if(score >= 100)
        {
            isEnding = true;
        }

        if(isEnding)
        {
            endingPanel.SetActive(true);
        }
    }

    IEnumerator CreateMaker()
    {
        while (isPlay)
        {
            yield return new WaitForSeconds(createTime);
            if(Global.timeScale == 0)
            {
                continue;
            }
            switch(nRandom)
            {
                case 1:
                    Instantiate(Resources.Load<GameObject>("TrashMaker_L"));
                    Debug.Log("1 Create");                                                                                                                     
                    break;
                case 2:
                    Instantiate(Resources.Load<GameObject>("TrashMaker_R"));
                    Debug.Log("2 Create");
                    break;
                case 3:
                    Instantiate(Resources.Load<GameObject>("TrashMaker_L"));
                    Instantiate(Resources.Load<GameObject>("TrashMaker_R"));
                    Debug.Log("3 Create");
                    break;
            }
        }
    }

    public void Clear()
    {
        Global.SceneMove("Map", true);
    }
}
