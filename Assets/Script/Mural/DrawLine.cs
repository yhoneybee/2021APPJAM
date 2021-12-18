using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawLine : MonoBehaviour
{
    public GameObject linePrefab;

    LineRenderer lr;
    List<Vector2> points = new List<Vector2>();
    public List<GameObject> lines = new List<GameObject>();

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            GameObject go = Instantiate(linePrefab);
            lr = go.GetComponent<LineRenderer>();
            lines.Add(go);
            points.Add(Camera.main.ScreenToWorldPoint(Input.mousePosition));
            lr.positionCount = 1;
            lr.SetPosition(0, points[0]);
        }
        else if(Input.GetMouseButton(0))
        {
            Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if(Vector2.Distance(points[points.Count - 1], pos) > 0.1f)
            {
                points.Add(pos);
                lr.positionCount++;
                lr.SetPosition(lr.positionCount - 1, pos);
            }
        }
        else if(Input.GetMouseButtonUp(0))
        {
            points.Clear();
        }
        // 전체 지우기
        if(Input.GetMouseButtonDown(1))
        {
            for (int i = 0; i < lines.Count; i++)
            {
                Destroy(lines[i]);
            }
                lines.Clear();
        }

        if (Input.GetMouseButtonDown(2))
        {
            Destroy(lines[lines.Count - 1]);
            lines.RemoveAt(lines.Count - 1);
        }
    }
}
