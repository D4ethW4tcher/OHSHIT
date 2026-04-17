using UnityEngine;

public static class InputHelper
{
    private static KeyCode lastKey;

    public static bool GetStandardMoveMultiInputKeys()
    {
        int count = 0;

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) count++;
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) count++;
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)) count++;
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) count++;

        return count > 1;
    }

    public static bool GetStandardMoveUpDirection()
    {
        if ((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) 
            && lastKey != KeyCode.S && lastKey != KeyCode.DownArrow)
        {
            lastKey = KeyCode.W;
            return true;
        }
        return false;
    }

    public static bool GetStandardMoveLeftDirection()
    {
        if ((Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)) 
            && lastKey != KeyCode.D && lastKey != KeyCode.RightArrow)
        {
            lastKey = KeyCode.A;
            return true;
        }
        return false;
    }

    public static bool GetStandardMoveDownDirection()
    {
        if ((Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)) 
            && lastKey != KeyCode.W && lastKey != KeyCode.UpArrow)
        {
            lastKey = KeyCode.S;
            return true;
        }
        return false;
    }

    public static bool GetStandardMoveRightDirection()
    {
        if ((Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)) 
            && lastKey != KeyCode.A && lastKey != KeyCode.LeftArrow)
        {
            lastKey = KeyCode.D;
            return true;
        }
        return false;
    }
}