using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class closeGame : MonoBehaviour
{
    public void quitGame() { Application.Quit(); }

    public void Update()
    {
        if (Input.GetKey(KeyCode.Escape)) quitGame();
    }
}
