using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomCursor : MonoBehaviour
{
    [SerializeField] Texture2D colorDropper;

    void changeCursor(Texture2D texture)
    {
        Cursor.SetCursor(texture, Vector2.up * 64, CursorMode.ForceSoftware);
    }
}
