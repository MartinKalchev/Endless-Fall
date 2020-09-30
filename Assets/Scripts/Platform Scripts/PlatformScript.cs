using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformScript : MonoBehaviour
{

    public float move_Speed = 2f;
    public float boundY = 6f;

    public bool movingPlatformLeft;
    public bool movingPlatformRight;
    public bool isBreakable;
    public bool isSpike;
    public bool isNormal;

    private Animator anim;


    void Awake()
    {
        if(isBreakable)
        {
            anim = GetComponent<Animator>();
        }
    }
   

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        Vector2 temp = transform.position;
        temp.y += move_Speed * Time.deltaTime;
        transform.position = temp;

        if(temp.y >= boundY)
        {
            //If the platform reaches 6 on the Y axis it is deactivated
            gameObject.SetActive(false);
        }
    }

    void BreakableDeactivate()
    {
        Invoke("DeactivateGameObject", 0.5f);
    }

    void DeactivateGameObject()
    {
        gameObject.SetActive(false);
    }

    //If the player reaches the spikes
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            if(isSpike)
            {
                collision.transform.position = new Vector2(1000.0f, 1000.0f);
                GameManager.instance.RestartGame();
            }
        }
    }

    //Check if 2 game objects collide
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            if(isBreakable)
            {
                anim.Play("Break");
            }
        }
    }

    //For every rigidbody collider as long as the player is standing on the moving platforms
    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            if (movingPlatformLeft)
                collision.gameObject.GetComponent<PlayerMovement>().PlatformMove(-1.0f);

            if (movingPlatformRight)
                collision.gameObject.GetComponent<PlayerMovement>().PlatformMove(1.0f);
        }
    }
}







