using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeColorOfDots : MonoBehaviour
{
    public Image act_selectedColor;
    public List<Color> colors;
    public ChangeColorOfDots firstBtn;
    public ChangeColorOfDots secondBtn;
    [HideInInspector]
    public int position=0;
    

    private void Start() { colors = firstBtn.colors; }

    public void increaseColor()
    {
        if (position < colors.Count-1)
            position++;
        else
            position = 0;
        act_selectedColor.color=colors[position];
        
        secondBtn.position = position;
    }

    public void decreaseColor()
    {
        if (position > 0)
            position--;
        else
            position = colors.Count-1;
        act_selectedColor.color = colors[position];
        
        firstBtn.position = position;
    }


}
