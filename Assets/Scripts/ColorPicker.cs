using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorPicker : MonoBehaviour
{
    [SerializeField] Slider[] sliders;
    [SerializeField] Image colorPreview;
    [SerializeField] ToolSelection toolSelection;

    public void pickColor()
    {
        colorPreview.color = new Color(sliders[0].value, sliders[1].value, sliders[2].value, sliders[3].value);
    }

    public void setCurrentColor()
    {
        sliders[0].value = toolSelection.primaryColor.color.r;
        sliders[1].value = toolSelection.primaryColor.color.g;
        sliders[2].value = toolSelection.primaryColor.color.b;
        sliders[3].value = toolSelection.primaryColor.color.a;
        pickColor();
    }
}
