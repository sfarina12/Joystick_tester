using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ChangePrecition : MonoBehaviour
{
    public SphereCollider sphere;
    public TextMeshProUGUI textPrecition;
    [Space]
    public GameObject firstBtn;
    public GameObject secondBtn;

    private void Update() { sphere.radius = Mathf.Lerp(sphere.radius, StringToInt(textPrecition.text), Time.deltaTime); }
    private float StringToInt(string text) { return float.Parse(text); }

    public void increasePrecition()
    {
        float number = StringToInt(textPrecition.text);
        if (number != 1f)
        {
            number += 0.1f;
            if (number == 1f) firstBtn.active = false;

            secondBtn.active = true;
            textPrecition.text = number.ToString();
        }
    }

    public void decreasePrecition()
    {
        float number = StringToInt(textPrecition.text);

        if (number != 0.2f)
        {
            number -= 0.1f;
            
            if (number < 0.3f) secondBtn.active = false;

            firstBtn.active = true;
            textPrecition.text = number.ToString();
        }
    }
}
