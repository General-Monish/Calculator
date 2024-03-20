using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // death support
    const float TeddyBearLifespanSeconds = 10;
    Timer deathTimer;
    // Start is called before the first frame update
    void Start()
    {
        const float minImpulseForce = 3f;
        const float maxImpulseForce = 5f;
        float angel=Random.Range(0,2*Mathf.PI);
        Vector2 direction=new Vector2(Mathf.Cos(angel),Mathf.Sin(angel));
        float magnitude=Random.Range(minImpulseForce,maxImpulseForce);
        GetComponent<Rigidbody2D>().AddForce(direction * magnitude , ForceMode2D.Impulse);

        // create and start timer
        deathTimer = gameObject.AddComponent<Timer>();
        deathTimer.Duration = TeddyBearLifespanSeconds;
        deathTimer.Run();
    }

    // Update is called once per frame
    void Update()
    {
        // kill teddy bear if death timer finished
        if (deathTimer.Finished)
        {
            Destroy(gameObject);
        }
    }
}
