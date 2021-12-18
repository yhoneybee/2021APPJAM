using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashMaker : MonoBehaviour
{
    private enum MakerType
    {
        NONE,
        LEFT,
        RIGHT
    };

    [SerializeField] private MakerType Type = MakerType.NONE;

    float makerSpeed;
    float fRandomSpawn;
    // Start is called before the first frame update
    void Start()
    {
        makerSpeed = 5;
        fRandomSpawn = Random.Range(0.5f, 1.5f);

        if (Type == MakerType.LEFT)
        {
            transform.localPosition = new Vector2(-9.4f, -3f);
        }
        else if (Type == MakerType.RIGHT)
        {
            transform.localPosition = new Vector2(9.4f, -3f);
        }

        StartCoroutine("MakeTrash");
    }

    // Update is called once per frame
    void Update()
    {
        if (Type == MakerType.LEFT)
        {
            transform.position += Vector3.right * makerSpeed * Global.timeScale * Time.deltaTime;
        }
        else if (Type == MakerType.RIGHT)
        {
            transform.position += Vector3.left * makerSpeed  * Global.timeScale * Time.deltaTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (Type == MakerType.LEFT)
        {
            if(collision.CompareTag("Right"))
            {
                Debug.Log("1Destroy");
                Destroy(this.gameObject);
            }
        }
        else if (Type == MakerType.RIGHT)
        {
            if (collision.CompareTag("Left"))
            {
                Debug.Log("2Destroy");
                Destroy(this.gameObject);
            }
        }
    }

    IEnumerator MakeTrash()
    {
        while (true)
        {
            yield return new WaitForSeconds(fRandomSpawn);
            Instantiate(Resources.Load<GameObject>("Trash"), transform.position, Quaternion.identity);
        }
    }
}
