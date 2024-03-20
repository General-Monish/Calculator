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
        GameObject players;
        int spriteNumber = Random.Range(0, 3);
        if(spriteNumber == 0)
        {
            players =Instantiate<GameObject>(sprite1,worldLocation,Quaternion.identity);
        }else if(spriteNumber == 1)
        {
            players = Instantiate<GameObject>(sprite2, worldLocation, Quaternion.identity);
        }
        else {

            players = Instantiate<GameObject>(sprite3, worldLocation, Quaternion.identity);
        }

    }
}
