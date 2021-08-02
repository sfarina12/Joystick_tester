using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ChangeDegreeOnOff : MonoBehaviour
{
    private TextMeshProUGUI text;
    [HideInInspector]
    public bool isOn=true;

    private void Start() { text = transform.gameObject.GetComponent<TextMeshProUGUI>(); }
    public void activateDisactivateDegree()
    {
        if (isOn) { isOn = false; text.text = "OFF"; }
        else { isOn = true; text.text = "ON"; }
    }
}
