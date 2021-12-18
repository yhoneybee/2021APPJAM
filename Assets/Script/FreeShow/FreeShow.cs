using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using TMPro;

public class FreeShow : Singletone<FreeShow>
{
    private float Score
    {
        get => score;
        set
        {
            txtScore.text = $"{score:#,0}";
            score = value;
        }
    }

    [SerializeField] private Canvas canvas;
    [SerializeField] private Animator animKeysParent;
    [SerializeField] private List<Animator> animKeys;
    [SerializeField] private List<GameObject> goNodeSpawns;
    [SerializeField] private List<GameObject> goNodeChecks;
    [SerializeField] private List<List<Node>> nodeLines;
    [SerializeField] private List<NodeMap> nodeMaps;
    [SerializeField] private Node originNode;
    [SerializeField] private TextMeshProUGUI txtScore;
    [SerializeField] private float score;
    [SerializeField] private TextMeshProUGUI originTxtResult;

    private Dictionary<int, KeyCode> keys;

    void Start()
    {
        Global.camera = Camera.main;
        Global.canvas = canvas;
        Score = 0;

        keys = new Dictionary<int, KeyCode>()
        {
            { 0,KeyCode.A },
            { 1,KeyCode.S },
            { 2,KeyCode.L },
            { 3,KeyCode.Semicolon },
        };

        animKeysParent.Play("AppearKeys");
        StartCoroutine(ESpawn());
    }

    void Update()
    {
        var pos0 = new Vector2(goNodeChecks[0].GetComponent<RectTransform>().position.x, goNodeChecks[0].GetComponent<RectTransform>().position.y);
        var pos1 = new Vector2(goNodeChecks[1].GetComponent<RectTransform>().position.x, goNodeChecks[1].GetComponent<RectTransform>().position.y);
        var pos2 = new Vector2(goNodeChecks[2].GetComponent<RectTransform>().position.x, goNodeChecks[2].GetComponent<RectTransform>().position.y);
        Debug.DrawRay(pos0, Vector2.up * 0.5f, Color.red, 0.1f);
        Debug.DrawRay(pos1, Vector2.up * 1f, Color.yellow, 0.1f);
        Debug.DrawRay(pos2, Vector2.up * 1.5f, Color.green, 0.1f);
        foreach (var item in keys)
        {
            if (Input.GetKeyDown(item.Value))
            {
                CheckNodeScore(item.Key);
            }
            if (Input.GetKeyUp(item.Value))
            {

            }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="index"></param>
    /// <returns>-1: out Range, 0: miss, 1: good, 2: great, 3: excellent</returns>
    public void CheckNodeScore(int index)
    {
        var pos = goNodeChecks[index].transform.position;
        var hit = Physics2D.Raycast(pos, Vector2.up, 1080, LayerMask.GetMask("Node"));
        if (!hit.transform) return;
        float dis = Vector2.Distance(hit.transform.position, pos);
        int check = dis switch
        {
            float f when 0 <= f && f < 0.5f => 3,
            float f when 0.5f <= f && f < 1f => 2,
            float f when 1f <= f && f < 1.5f => 1,
            float f when 1.5f <= f && f < 3 => 0,
            _ => -1,
        };
        if (check >= 0)
        {
            Destroy(hit.transform.gameObject);
            SpawnTxtResult(check);
        }
    }

    public TextMeshProUGUI SpawnTxtResult(int check)
    {
        var txt = Instantiate(originTxtResult, new Vector3(-650, -130), Quaternion.identity);
        txt.GetComponent<RectTransform>().SetParent(Global.canvas.transform, false);
        switch (check)
        {
            case 0:
                txt.text = "Miss";
                txt.color = Color.red;
                break;
            case 1:
                txt.text = "Good";
                txt.color = Color.yellow;
                Score += 100;
                break;
            case 2:
                txt.text = "Great";
                txt.color = Color.green;
                Score += 200;
                break;
            case 3:
                txt.text = "Excellent";
                txt.color = Color.cyan;
                Score += 400;
                break;
        }
        return txt;
    }

    private IEnumerator ESpawn()
    {
        if (nodeMaps.Count == 0) yield break;
        yield return new WaitForSeconds(3 * Global.timeScale);
        var nodeMap = nodeMaps[Random.Range(0, nodeMaps.Count)];
        foreach (var node in nodeMap.nodes)
        {
            if (node.pos0) Instantiate(originNode, Global.canvas.transform, false).transform.position = goNodeSpawns[0].transform.position;
            if (node.pos1) Instantiate(originNode, Global.canvas.transform, false).transform.position = goNodeSpawns[1].transform.position;
            if (node.pos2) Instantiate(originNode, Global.canvas.transform, false).transform.position = goNodeSpawns[2].transform.position;
            if (node.pos3) Instantiate(originNode, Global.canvas.transform, false).transform.position = goNodeSpawns[3].transform.position;
            yield return new WaitForSeconds(node.nextSpawnDelay * Global.timeScale);
        }
    }
}
