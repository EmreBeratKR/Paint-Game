using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToolSelection : MonoBehaviour
{
    public Image primaryColor;
    [SerializeField] Image colorPreview;
    [SerializeField] RectTransform colorPalette;
    [SerializeField] ColorPicker colorPicker;
    public Color pickedColor;
    public int choosenTool;

    public void selectTool(Transform tool)
    {
        choosenTool = tool.GetSiblingIndex();
        for (int c = 0; c < transform.childCount; c++)
        {
            if (c == choosenTool)
            {
                transform.GetChild(c).GetComponent<Image>().color = Color.gray;
            }
            else
            {
                transform.GetChild(c).GetComponent<Image>().color = Color.white;
            }
        }
    }

    public void openColorPalette()
    {
        colorPicker.setCurrentColor();
        colorPalette.gameObject.SetActive(true);
    }

    public void closeColorPalette(bool saveColor)
    {
        colorPalette.gameObject.SetActive(false);
        if (saveColor)
        {
            primaryColor.color = colorPreview.color;
            pickedColor = colorPreview.color;
        }
    }
}
