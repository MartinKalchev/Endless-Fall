using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBounds : MonoBehaviour
{
    public float minX = -4.5f;
    public float maxX = 4.5f;
    public float minY = -5.2f;
    public float maxY = 4.3f;

    private bool outOfBounds;

    // Update is called once per frame
    void Update()
    {
        CheckBounds();
    }

    void CheckBounds()
    {
        Vector2 temp = transform.position;

        if (temp.x > maxX)
            temp.x = maxX;

        if (temp.x < minX)
            temp.x = minX;

        transform.position = temp;

        if (temp.y <= minY)
            if (!outOfBounds)
            {
                outOfBounds = true;
                GameManager.instance.RestartGame();
            }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "TopSpike")
        {
            transform.position = new Vector2(1000.0f, 1000.0f);
            GameManager.instance.RestartGame();
        }
    }
}
