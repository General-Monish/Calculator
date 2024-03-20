using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ScreenUtils 
{
    #region Fields

    static int screenWidth;
    static int screenHeight;

    static float screenLeft;
    static float screenTop;
    static float screenRight;
    static float screenBottom;

    #endregion

    #region Properties

    // Get the left edge co ordinates of world Cordinates
    public static float ScreenLeft
    {
        get
        {
            CheckScreenSizeChanged();
            return screenLeft;
        }
    }

    public static float ScreenTop
    {
        get
        {
            CheckScreenSizeChanged();
            return screenTop;
        }
    }

    public static float ScreenRight
    {
        get
        {
            CheckScreenSizeChanged();
            return screenRight;
        }
    }

    public static float ScreenBottom
    {
        get
        {
            CheckScreenSizeChanged();
            return screenBottom;
        }
    }

    #endregion

    public static void Initilise()
    {
        screenWidth = Screen.width;
        screenHeight = Screen.height;

        // saving screen cordinates in world cordinates
        float screenZ = -Camera.main.transform.position.z;
        Vector3 LowerLeftCornerScreen = new Vector3(0, 0, screenZ);
        Vector3 UpperRightCornerScreen= new Vector3(screenWidth, screenHeight, screenZ);
        Vector3 LowerLeftCornerWorld=Camera.main.ScreenToWorldPoint(LowerLeftCornerScreen);
        Vector3 UpperRightCornerWorld=Camera.main.ScreenToWorldPoint(UpperRightCornerScreen);

        screenLeft=LowerLeftCornerWorld.x;
        screenTop=UpperRightCornerWorld.y;
        screenRight = UpperRightCornerWorld.x;
        screenBottom=LowerLeftCornerWorld.y;
    }

    static void CheckScreenSizeChanged()
    {
        if (screenWidth != Screen.width ||
            screenHeight != Screen.height)
        {
            Initilise();
        }
    }
}