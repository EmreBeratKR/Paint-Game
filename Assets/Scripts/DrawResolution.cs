using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawResolution : MonoBehaviour
{
    [SerializeField] RectTransform pixel;
    [SerializeField] List<Vector2> resolutions;
    Vector2 resolutionRatio;
    int choosenResolution = 1;

    void Start()
    {
        resolutionRatio = ratio();
        for (int i = 1; i <= 4; i++)
        {
            resolutions.Add(resolutionRatio * i * 2);
        }
        createPixels();
    }

    void createPixels()
    {
        float pixelEdge = GetComponent<RectTransform>().rect.width / resolutions[choosenResolution].x;
        pixel.sizeDelta = Vector2.one * pixelEdge;
        for (int y = 0; y < resolutions[choosenResolution].y; y++)
        {
            for (int x = 0; x < resolutions[choosenResolution].x; x++)
            {
                RectTransform temp = Instantiate(pixel, Vector3.zero, Quaternion.identity, transform);
                temp.localPosition = new Vector3(pixelEdge * x - GetComponent<RectTransform>().rect.width / 2f, pixelEdge * y - GetComponent<RectTransform>().rect.height / 2f);
            }
        }
    }

    Vector2 ratio()
    {
        float width = GetComponent<RectTransform>().rect.width;
        float height = GetComponent<RectTransform>().rect.height;
        float smallest = width < height ? width : height;
        int biggestCommonDivisor = 1;
        for (int i = 1; i <= smallest; i++)
        {
            if (width % i == 0 && height % i == 0)
            {
                biggestCommonDivisor = i;
            }
        }
        return GetComponent<RectTransform>().rect.size / biggestCommonDivisor;
    }

}
