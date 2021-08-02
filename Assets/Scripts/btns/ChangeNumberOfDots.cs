using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ChangeNumberOfDots : MonoBehaviour
{
    public TextMeshProUGUI textNumberOfDots;
    public GameObject moreDots;
    public GameObject lessDots;

    private int StringToInt(string text) { return Int32.Parse(text); }

    public void increaseDots()
    {
        int number=StringToInt(textNumberOfDots.text);

        lessDots.active = true;

        number++;

        if (number == 100) moreDots.active = false;

        textNumberOfDots.text=number.ToString();
    }

    public void decreaseDots()
    {
        int number = StringToInt(textNumberOfDots.text);

        moreDots.active = true;

        number--;

        if(number == 4) lessDots.active = false;

        textNumberOfDots.text = number.ToString();
    }
}
