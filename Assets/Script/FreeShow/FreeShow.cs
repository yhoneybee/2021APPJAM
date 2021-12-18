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
    /// <returns>-1: miss, 0: out Range, 1: good, 2: great, 3: excellent</returns>
    public int CheckNodeScore(int index)
    {
        var pos = goNodeChecks[index].transform.position;
        var hit = Physics2D.Raycast(pos, Vector2.up, 1080, LayerMask.GetMask("Node"));
        if (!hit.transform) return 0;
        float dis = Vector2.Distance(hit.transform.position, pos);
        int check = dis switch
        {
            float f when 0 <= f && f < 0.5f => 3,
            float f when 0.5f <= f && f < 1f => 2,
            float f when 1f <= f && f < 1.5f => 1,
            float f when 1.5f <= f && f < 3 => -1,
            _ => 0,
        };
        if (check != 0) Destroy(hit.transform.gameObject);

        return check;
    }

    private IEnumerator ESpawn()
    {
        if (nodeMaps.Count == 0) yield break;
        yield return new WaitForSeconds(3);
        var nodeMap = nodeMaps[Random.Range(0, nodeMaps.Count)];
        foreach (var node in nodeMap.nodes)
        {
            if (node.pos0) Instantiate(originNode, goNodeSpawns[0].transform, false);
            if (node.pos1) Instantiate(originNode, goNodeSpawns[1].transform, false);
            if (node.pos2) Instantiate(originNode, goNodeSpawns[2].transform, false);
            if (node.pos3) Instantiate(originNode, goNodeSpawns[3].transform, false);
            yield return new WaitForSeconds(node.nextSpawnDelay);
        }
    }
}
