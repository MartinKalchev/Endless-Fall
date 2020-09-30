using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D myBody;

    public float moveSpeed = 8.0f;

    // Start is called before the first frame update
    void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame fixed body used to move object with rigid body
    void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        //Move
        if (Input.GetAxisRaw("Horizontal") > 0.0f)
            myBody.velocity = new Vector2(moveSpeed, myBody.velocity.y);

        if (Input.GetAxisRaw("Horizontal") < 0.0f)
            myBody.velocity = new Vector2(-moveSpeed, myBody.velocity.y);
    }

    //Used in the moving platforms
    public void PlatformMove(float x)
    {
        myBody.velocity = new Vector2(x, myBody.velocity.y);
    }
}
