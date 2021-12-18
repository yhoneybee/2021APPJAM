using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct NodeInfo
{
    public bool pos0, pos1, pos2, pos3;
    [Range(0.0f, 2.0f)]
    public float nextSpawnDelay;
}

[CreateAssetMenu(fileName = "NodeMap", menuName = "Datas/NodeMap", order = 0)]
public class NodeMap : ScriptableObject
{
    public List<NodeInfo> nodes;
}
