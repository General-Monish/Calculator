using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    GameObject playerPrefab;

    Timer spawnTimer;

    [SerializeField]
    Sprite sprite1;
    [SerializeField]
    Sprite sprite2;
    [SerializeField]
    Sprite sprite3;

    const float minSpawnDelay=1;
    const float maxSpawnDelay=2;

    const int spawnBoardSize = 100;
    int minSpawnX;
    int minSpawnY;
    int maxSpawnX;
    int maxSpawnY;

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
        GameObject player = Instantiate(playerPrefab) as GameObject;
        player.transform.position = worldLocation;

        // setting random sprite for new player
        SpriteRenderer spriteRenderer = player.GetComponent<SpriteRenderer>();
        int spriteNumber = Random.Range(0, 3);
        if(spriteNumber == 0)
        {
            spriteRenderer.sprite = sprite1;
        }else if(spriteNumber == 1)
        {
            spriteRenderer.sprite = sprite2;
        }
        else {

            spriteRenderer.sprite = sprite3;
        };
    }
}
