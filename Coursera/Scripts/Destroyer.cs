using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    [SerializeField]
    GameObject explosionPrefab;
    Timer destroyTimer;
    // Start is called before the first frame update
    void Start()
    {
        destroyTimer=gameObject.AddComponent<Timer>();
        destroyTimer.Duration = 1;
        destroyTimer.Run();
    }

    // Update is called once per frame
    void Update()
    {
        if (destroyTimer.Finished)
        {
            destroyTimer.Run ();

            // to explode n destroy players
            GameObject Monkey = GameObject.FindWithTag("Monkey");
            if (Monkey != null )
            {
                
                if (explosionPrefab != null)
                {
                    Debug.Log("Boom");
                    Instantiate<GameObject>(explosionPrefab, Monkey.transform.position, Quaternion.identity);
                    Destroy(Monkey);
                }
                else
                {
                    Debug.LogError("Explosion prefab is not assigned!");
                }
                
            }
        }
    }
}
