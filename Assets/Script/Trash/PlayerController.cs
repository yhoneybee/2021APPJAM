using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private Transform playerTransform;
    private Rigidbody2D playerRigid;
    private SpriteRenderer playerSprite;
    private Animator animator;

    private float speed;
    private float jumpPower;
    private bool isJumping;

    // Start is called before the first frame update
    void Start()
    {
        playerTransform = GetComponent<Transform>();
        playerRigid = GetComponent<Rigidbody2D>();
        playerSprite = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();

        speed = 5;
        jumpPower = 10;
        isJumping = false;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Jump();
    }
    void Move()
    {
        float h = Input.GetAxisRaw("Horizontal");

        if (h < 0)
        {
            RayFunction(Vector2.left);
            animator.SetBool("Right", false);
            //playerSprite.sprite = Resources.Load<Sprite>("Sprite/PlayerLeft");
            animator.SetBool("Left", true);
        }
        else if (h > 0)
        {
            RayFunction(Vector2.right);
            animator.SetBool("Left", false);
            //playerSprite.sprite = Resources.Load<Sprite>("Sprite/PlayerRight");
            animator.SetBool("Right", true);
        }
        else
        {
            animator.SetBool("Left", false);
            animator.SetBool("Right",false);
        }
        playerTransform.localPosition += (Vector3.right * h * speed * Global.timeScale * Time.deltaTime);
    }

    void Jump()
    {
        if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            if(!isJumping)
            {
                playerRigid.AddForce(Vector3.up * jumpPower, ForceMode2D.Impulse);
                isJumping = true;
            }
        }
    }

    void RayFunction(Vector2 direction)
    {
        Debug.DrawRay(new Vector2(transform.position.x, transform.position.y - 2), direction * 3f, Color.red);
        RaycastHit2D rayHit = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y - 2), direction, 3f, LayerMask.GetMask("Trash"));

        if (rayHit.collider != null)
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                PickingTrashManager.Instance.score += 1;
                SoundManager.Instance.Play("TrashPickup", SoundType.EFFECT);
                Destroy(rayHit.transform.gameObject);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.CompareTag("Floor"))
        {
            isJumping = false;
        }
    }


}
