using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    [HideInInspector]
    public float HorizontalAxis = 0;
    public float HorizontalAc = 2;
    bool left = false, right = false;
    

    void Update()
    {
        if (left)
        {
            LeftProcess();
        }
        else if (right)
        {
            RightProcess();
        }
        else
        {
            HorizontalAxis = 0;
        }
    }

    void LeftProcess()
    {
        if (HorizontalAxis > 0)
        {
            HorizontalAxis = 0f;
        }
        else
        {
            HorizontalAxis -= HorizontalAc * Time.deltaTime;
        }

        if (HorizontalAxis < -1)
        {
            HorizontalAxis = -1;
        }
    }

    void RightProcess()
    {
        if (HorizontalAxis < 0)
        {
            HorizontalAxis = 0f;
        }
        else
        {
            HorizontalAxis += HorizontalAc * Time.deltaTime;
        }

        if (HorizontalAxis > 1)
        {
            HorizontalAxis = 1;
        }
    }

    public void LeftDown()
    {
        left = true;
    }
    public void LeftUp()
    {
        left = false;
    }
    public void RightDown()
    {
        right = true;
    }
    public void RightUp()
    {
        right = false;
    }
}
