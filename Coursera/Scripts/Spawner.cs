using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    GameObject playerPrefab;

    Timer spawnTimer;

    [SerializeField]
    GameObject sprite1;
    [SerializeField]
    GameObject sprite2;
    [SerializeField]
    GameObject sprite3;

    const float minSpawnDelay=1;
    const float maxSpawnDelay=2;

    const int spawnBoardSize = 100;
    int minSpawnX;
    int minSpawnY;
    int maxSpawnX;
    int maxSpawnY;

    // Collision free spwan support
    const int maxSpawnTries = 20;
    float playerColliderHalfWidth;
    float playerColliderHalfHeight;
    Vector2 min=new Vector2();
    Vector2 max=new Vector2();


    // Start is called before the first frame update
    void Start()
    {
        minSpawnX = spawnBoardSize;
        maxSpawnX=Screen.width-spawnBoardSize;
        minSpawnY = spawnBoardSize;
        maxSpawnY=Screen.height-spawnBoardSize;

        // create and start timer
        spawnTimer=gameObject.AddComponent<Timer>();
        spawnTimer.Duration = Random.Range(minSpawnDelay, maxSpawnDelay);
        spawnTimer.Run();

        // spawn and destroy a player to cache collider values
        GameObject tempPlayer=Instantiate<GameObject>(
            playerPrefab,Vector3.zero,Quaternion.identity);
        BoxCollider2D collider=tempPlayer.GetComponent<BoxCollider2D>();
        playerColliderHalfWidth=collider.size.x/2;
        playerColliderHalfHeight=collider.size.y/2;
        Destroy(tempPlayer);
    }

    // Update is called once per frame
    void Update()
    {
        if (spawnTimer.Finished)
        {
            SpawnPlayer();
            spawnTimer.Duration=Random.Range(minSpawnDelay, maxSpawnDelay);
            spawnTimer.Run();
        }
    }

    void SpawnPlayer()
    {
        Vector3 location=new Vector3(Random.Range(minSpawnX,maxSpawnX),Random.Range(minSpawnY,maxSpawnY),-Camera.main.transform.position.z);
        Vector3 worldLocation=Camera.main.ScreenToWorldPoint(location);
       
        SetMinAndMax(worldLocation);
        int spawntries = 1;
        while (Physics2D.OverlapArea(min, max) != null && spawntries <= maxSpawnTries)
        {
            // changinglocations and pointing new rectangles
            location.x=Random.Range(minSpawnX,maxSpawnX);
            location.y=Random.Range(minSpawnY, maxSpawnY);
            worldLocation = Camera.main.ScreenToWorldPoint(location);
            SetMinAndMax (worldLocation);

            spawntries++;
        }

        if(Physics2D.OverlapArea(min, max) == null)
        {
            GameObject player = Instantiate(playerPrefab) as GameObject;
            player.transform.position = worldLocation;
            // setting random sprite for new player
            GameObject players;
            int spriteNumber = Random.Range(0, 3);
            if (spriteNumber == 0)
            {
                players = Instantiate<GameObject>(sprite1, worldLocation, Quaternion.identity);
            }
            else if (spriteNumber == 1)
            {
                players = Instantiate<GameObject>(sprite2, worldLocation, Quaternion.identity);
            }
            else
            {

                players = Instantiate<GameObject>(sprite3, worldLocation, Quaternion.identity);
            }

        }

    }


    // set min and max for player collision rectangle
    void SetMinAndMax(Vector3 location)
    {
        min.x = location.x-playerColliderHalfWidth;
        min.y= location.y-playerColliderHalfHeight;
        max.x = location.x + playerColliderHalfWidth;
        max.y = location.y-playerColliderHalfHeight;
    }
}
