﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class size : MonoBehaviour
{
    bool fulltrg = false;
    // Start is called before the first frame update
    void Start()
    {
        Screen.SetResolution(1280, 720, false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown (KeyCode.F11 ))
        {
            if(fulltrg == false)
            {
                fulltrg = true;
                Screen.SetResolution(1920, 1080, false);
            }
            else if(fulltrg == true)
            {
                fulltrg = false;
                Screen.SetResolution(1280, 720, false);
            }
        }
    }

}
