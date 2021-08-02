using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckForController : MonoBehaviour
{
    [HideInInspector]
    public bool isControllerConnected = false;
    [Space]
    public Animator noControllerAnimator;

    void Update()
    {
        if (Input.GetJoystickNames().Length>0 && Input.GetJoystickNames()[0].Length > 0)
        {
            if(!isControllerConnected)
                noControllerAnimator.Play("fadeOUT");
            isControllerConnected = true; 
        }
        else
        {
            isControllerConnected = false;
            noControllerAnimator.Play("fadeIN");
        }
    }
}
