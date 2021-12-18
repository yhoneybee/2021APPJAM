using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Human : MonoBehaviour
{
    public Sprite[] sprites;
    public Image img;
    public List<Vector2> v;
    public bool hasCoal;
    public CoalObj coalObj;
    public bool isPlayer;
    public bool isFirst;
    public bool isLast;
    public int CoalPos
    {
        get => coalPos;
        set
        {
            coalPos = value;
            img.sprite = sprites[coalPos];
            if (coalObj)
            {
                coalObj.rtrn.anchoredPosition = Vector3.zero;
                coalObj.rtrn.anchoredPosition += v[coalPos] * DELTA_POS + GetComponent<RectTransform>().anchoredPosition;
            }
        }
    }
    [SerializeField] private int coalPos;
    private readonly int DELTA_POS = 125;

    void Start()
    {
        coalPos = 0;
        v = new List<Vector2>()
        {
            Vector2.left,
            Vector2.up,
            Vector2.right,
        };

        StartCoroutine(EProcess());
    }
    void Update()
    {

    }

    private IEnumerator EProcess()
    {
        var wait = new WaitForSeconds(1);
        while (true)
        {
            if (isFirst)
            {
                if (!hasCoal)
                {
                    coalObj = Instantiate(Coal.Instance.originCoal, Coal.Instance.rtrnCoalParent, false);
                    CoalPos = 0;
                    hasCoal = true;
                }
                else if (CoalPos < 2 && hasCoal)
                {
                    CoalPos++;
                }
            }
            else if (isPlayer)
            {
                var human = Coal.Instance.humans[Coal.Instance.humans.IndexOf(this) - 1];
                if (Input.GetKey(KeyCode.A) && human.hasCoal && human.CoalPos == 2)
                {
                    human.hasCoal = false;
                    hasCoal = true;
                    coalObj = human.coalObj;
                    human.coalObj = null;
                    CoalPos = 1;
                }
                if (Input.GetKey(KeyCode.W) && CoalPos == 1 && hasCoal)
                {
                    CoalPos = 2;
                }
            }
            else
            {
                var human = Coal.Instance.humans[Coal.Instance.humans.IndexOf(this) - 1];
                if (!hasCoal && human.CoalPos == 2 && human.hasCoal)
                {
                    human.hasCoal = false;
                    hasCoal = true;
                    coalObj = human.coalObj;
                    CoalPos = 0;
                }
                else if (CoalPos < 2 && hasCoal)
                {
                    CoalPos++;
                    if (CoalPos == 2 && isLast)
                    {
                        Destroy(coalObj.gameObject);
                        Coal.Instance.GiveCoalCount++;
                        hasCoal = false;
                        CoalPos = 0;
                    }
                }
            }
            yield return wait;
        }
    }
}
