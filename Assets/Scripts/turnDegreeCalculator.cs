using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class turnDegreeCalculator : MonoBehaviour
{
    public ChangeDegreeOnOff changeDegree;
    public Transform pivotLighter;
    TextMeshPro text;

    private void Start() { text = transform.gameObject.GetComponent<TextMeshPro>(); }

    void Update()
    {
        if (changeDegree.isOn)
            if ((Input.GetAxis("Horizontal") != 0) || (Input.GetAxis("Vertical") != 0))
            {
                int degree = (int)pivotLighter.rotation.eulerAngles.y;
                degree -= 360;
                degree *= -1;
                text.text = degree + "°";
            }
            else
                text.text = "0°";
        else
            text.text = "";
    }
}
