using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class EventController : MonoBehaviour
{
    ToolSelection toolSelection;
    void Start()
    {
        toolSelection = GameObject.FindGameObjectWithTag("Tools Panel").GetComponent<ToolSelection>();

        EventTrigger trigger = GetComponent<EventTrigger>();
        //set pointerDown trigger
        EventTrigger.Entry pointerDown = new EventTrigger.Entry();
        pointerDown.eventID = EventTriggerType.PointerDown;
        pointerDown.callback.AddListener((data) => { onPointerDown((PointerEventData)data); });
        trigger.triggers.Add(pointerDown);
        //set pointerEnter trigger
        EventTrigger.Entry pointerEnter = new EventTrigger.Entry();
        pointerEnter.eventID = EventTriggerType.PointerEnter;
        pointerEnter.callback.AddListener((data) => { onPointerEnter((PointerEventData)data); });
        trigger.triggers.Add(pointerEnter);
    }

    public void onPointerDown(PointerEventData data)
    {
        if (toolSelection.choosenTool == toolSelection.transform.Find("Pen Tool").GetSiblingIndex())
        {
            GetComponent<Image>().color = toolSelection.pickedColor;
        }
        else if (toolSelection.choosenTool == toolSelection.transform.Find("Erase Tool").GetSiblingIndex())
        {
            GetComponent<Image>().color = Color.clear;
        }
        else if (toolSelection.choosenTool == toolSelection.transform.Find("Color Dropper Tool").GetSiblingIndex())
        {
            toolSelection.pickedColor = GetComponent<Image>().color;
            toolSelection.primaryColor.color = toolSelection.pickedColor;
        }
    }

    public void onPointerEnter(PointerEventData data)
    {
        if (Input.GetMouseButton(0))
        {
            if (toolSelection.choosenTool == toolSelection.transform.Find("Pen Tool").GetSiblingIndex())
            {
                GetComponent<Image>().color = toolSelection.pickedColor;
            }
            else if (toolSelection.choosenTool == toolSelection.transform.Find("Erase Tool").GetSiblingIndex())
            {
                GetComponent<Image>().color = Color.clear;
            }
            else if (toolSelection.choosenTool == toolSelection.transform.Find("Color Dropper Tool").GetSiblingIndex())
            {
                toolSelection.pickedColor = GetComponent<Image>().color;
                toolSelection.primaryColor.color = toolSelection.pickedColor;
            }
        }
    }
}
