using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playerr : MonoBehaviour
{
    float colliderHalfWidth;
    float colliderHalfHeight;
    // Start is called before the first frame update
    void Start()
    {
        BoxCollider2D collider = GetComponent<BoxCollider2D>();
        colliderHalfWidth= collider.size.x/2;
        colliderHalfHeight = collider.size.y/2;
    }

    // Update is called once per frame
    void Update()
    {
        
        Vector3 position=Input.mousePosition;
        position.z= -Camera.main.transform.position.z;
        position=Camera.main.ScreenToWorldPoint(position);

        // moving char
        transform.position = position;
        ClampInScreen();
    }

    void ClampInScreen()
    {
        Vector3 position=transform.position;

        // clamping horizintally
        if (position.x - colliderHalfWidth < ScreenUtils.ScreenLeft) // position.x means ceter of player
        {
            position.x = ScreenUtils.ScreenLeft+colliderHalfWidth;
        }else if(position.x + colliderHalfWidth > ScreenUtils.ScreenRight)
        {
            position.x= ScreenUtils.ScreenRight-colliderHalfWidth;
        }

        // clamping vertically
        if(position.y+colliderHalfHeight > ScreenUtils.ScreenTop)
        {
            position.y= ScreenUtils.ScreenTop-colliderHalfHeight;
        }else if(position.y-colliderHalfHeight < ScreenUtils.ScreenBottom)
        {
            position.y=ScreenUtils.ScreenBottom+colliderHalfHeight;
        }

        transform.position = position;
    }
}
