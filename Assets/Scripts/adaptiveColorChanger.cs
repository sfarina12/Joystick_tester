using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class adaptiveColorChanger : MonoBehaviour
{
    public ChangeColorOfDots colorChanger;
    public Image imageToChange;

    public void Start() { imageToChange.color = colorChanger.colors[colorChanger.position]; }
    void Update() { imageToChange.color = Color.Lerp(imageToChange.color, colorChanger.act_selectedColor.color, Time.deltaTime); }
}
