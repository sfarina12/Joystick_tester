using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenSettings : MonoBehaviour
{

    public List<GameObject> settingsButtons;

    public void openOrCloseMenu()
    {
        if (settingsButtons[0].gameObject.active)
            foreach (GameObject btn in settingsButtons)
                btn.active = false;
        
        else
            foreach (GameObject btn in settingsButtons)
                btn.active = true;
    }
}
