using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerChanager : MonoBehaviour
{
    [SerializeField]
    GameObject playerPrefab1;
    [SerializeField]
    GameObject playerPrefab2;
    [SerializeField]
    GameObject playerPrefab3;

    GameObject currentPlayerPrefab;
    bool previousPlayerPrefabInput=false;
    // Start is called before the first frame update
    void Start()
    {
        currentPlayerPrefab=Instantiate<GameObject>(playerPrefab1,Vector3.zero,Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetAxis("PlayerChanage")>0)
        {
            if (!previousPlayerPrefabInput)
            {
                previousPlayerPrefabInput=true;

                Vector3 positions = currentPlayerPrefab.transform.position;
                Destroy(currentPlayerPrefab);

                int prefabNumber = Random.Range(0, 3);
                if (prefabNumber == 0)
                {
                    currentPlayerPrefab = Instantiate<GameObject>(playerPrefab1, positions, Quaternion.identity);
                }
                else if (prefabNumber == 1)
                {
                    currentPlayerPrefab = Instantiate<GameObject>(playerPrefab2, positions, Quaternion.identity);
                }
                else
                {
                    currentPlayerPrefab = Instantiate<GameObject>(playerPrefab3, positions, Quaternion.identity);
                }

            }
        }
        else
        {
            previousPlayerPrefabInput = false;
        }
    }
}
// Nothing
