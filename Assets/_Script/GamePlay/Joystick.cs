﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Joystick : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
{
    public static Joystick instance;
    private RectTransform background;
    private RectTransform handle;
    private Vector2 inputVector;
    private void OnEnable()
    {
        instance = this;
    }
    private void OnDisable()
    {
        instance = null;
    }
    void Awake()
    {
        background = GetComponent<RectTransform>();
        handle = transform.GetChild(0).GetComponent<RectTransform>();
    }
    public void OnDrag(PointerEventData eventData)
    {
        Vector2 pos;
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(background, eventData.position, eventData.pressEventCamera, out pos))
        {
            pos.x = (pos.x / background.sizeDelta.x);
            pos.y = (pos.y / background.sizeDelta.y);

            inputVector = new Vector2(pos.x * 2, pos.y * 2);
            inputVector = (inputVector.magnitude > 1.0f) ? inputVector.normalized : inputVector;

            handle.anchoredPosition = new Vector2(inputVector.x * (background.sizeDelta.x / 2), inputVector.y * (background.sizeDelta.y / 2));
        }
    }
    public void OnPointerDown(PointerEventData eventData) //Sự kiện bấm vào Jstick
    {
        OnDrag(eventData);
    }
    public void OnPointerUp(PointerEventData eventData) //Sự kiện thả ra
    {
        inputVector = Vector2.zero;
        handle.anchoredPosition = Vector2.zero;
    }
    public float Horizontal()
    {
        return inputVector.x;
    }
    public float Vertical()
    {
        return inputVector.y;
    }
}

