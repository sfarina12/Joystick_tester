using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class powerCalculator : MonoBehaviour
{
    public ChangeDegreeOnOff changePower;
    public Transform distanceLighter;
    TextMeshPro text;

    private void Start() { text = transform.gameObject.GetComponent<TextMeshPro>(); }

    void Update()
    {
        if (changePower.isOn)
        {
            float power = distanceLighter.localPosition.x;

            float value = Mathf.Lerp(0, 100, Mathf.InverseLerp(0, 2.06f, power));

            text.text = value.ToString("F0") + "%";
        }
        else
            text.text = "";
    }
}
