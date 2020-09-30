using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatfrormSpawner : MonoBehaviour
{

    public GameObject platform;
    public GameObject spikePlatform;
    public GameObject[] movingPlatforms;
    public GameObject breakablePlatform;

    public float platformSpawnTimer = 0.5f;
    private float currentPlatformSpawnTimer;

    private int platformSpawnCount;

    public float minX = -5.0f;
    public float maxX = 4.0f;

    // Start is called before the first frame update
    void Start()
    {
        currentPlatformSpawnTimer = platformSpawnTimer;
    }

    // Update is called once per frame
    void Update()
    {
        SpawnPlatforms();
    }

    void SpawnPlatforms()
    {
        //Denote when the value is larger than platformSpawnTimer
        currentPlatformSpawnTimer += Time.deltaTime;

        if (currentPlatformSpawnTimer >= platformSpawnTimer)
        {
            //Spawn platform
            platformSpawnCount++;

            Vector3 temp = transform.position;
            //Spawn at a random position between min and max x axis
            temp.x = Random.Range(minX, maxX);

            GameObject newPlatform = null;

            if (platformSpawnCount < 2)
            {
                newPlatform = Instantiate(platform, temp, Quaternion.identity);
            }
            else if (platformSpawnCount == 2)
            {
                if (Random.Range(0, 2) > 0)
                {
                    //Spawn regular platform
                    newPlatform = Instantiate(platform, temp, Quaternion.identity);
                }
                else
                {
                    //Spawn a moving platform
                    newPlatform = Instantiate(movingPlatforms[Random.Range(0, movingPlatforms.Length)], temp, Quaternion.identity);
                }
            }
            else if (platformSpawnCount == 3)
            {
                if (Random.Range(0, 2) > 0)
                {
                    //Spawn regular platform
                    newPlatform = Instantiate(platform, temp, Quaternion.identity);
                }
                else
                {
                    //Spawn a spike platform
                    newPlatform = Instantiate(spikePlatform, temp, Quaternion.identity);
                }
            }
            else if (platformSpawnCount == 4)
            {
                if (Random.Range(0, 2) > 0)
                {
                    //Spawn regular platform
                    newPlatform = Instantiate(platform, temp, Quaternion.identity);
                }
                else
                {
                    //Spawn a breakable platform
                    newPlatform = Instantiate(breakablePlatform, temp, Quaternion.identity);
                }
                //Reset spawn count in order to keep spawning
                platformSpawnCount = 0;
            }

            if(newPlatform != null)
                newPlatform.transform.parent = transform;

            //Reset spawn timer in order to keep spawning
            currentPlatformSpawnTimer = 0;
        }
    }
}








