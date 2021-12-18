using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Transform playerTransform;
    private Rigidbody2D playerRigid;

    private float speed;
    private float jumpPower;
    private bool isJumping;

    // Start is called before the first frame update
    void Start()
    {
        playerTransform = GetComponent<Transform>();
        playerRigid = GetComponent<Rigidbody2D>();

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

        //playerRigid.AddForce(Vector2.right * h, ForceMode2D.Impulse);

        //if(playerRigid.velocity.x > maxSpeed)
        //{
        //    playerRigid.velocity = new Vector2(maxSpeed, playerRigid.velocity.y);
        //}
        //else if(playerRigid.velocity.x < maxSpeed * (-1))
        //{
        //    playerRigid.velocity = new Vector2(maxSpeed * (-1), playerRigid.velocity.y);
        //}

        playerTransform.Translate(Vector3.right * h * speed * Time.deltaTime);
    }

    void Jump()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(!isJumping)
            {
                playerRigid.AddForce(Vector3.up * jumpPower, ForceMode2D.Impulse);
                isJumping = true;
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
