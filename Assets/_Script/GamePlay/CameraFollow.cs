using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private float Yaxis;
    private float Xaxis;
    [SerializeField]
    private float rotateSencitivity = 3f;
    [SerializeField]
    private float rotateMax = 50;
    [SerializeField]
    private float rotateMin = -10;
    [SerializeField]
    private float smoothTime = 0.12f;
    [SerializeField]
    private Vector3 targetRotation;
    [SerializeField]
    private Vector3 currentVel;
    private void Update()
    {
        CameraMove();
    }
    public void CameraMove()
    {
        if (GameManager.instance.isTouch)
        {
            InputScrollByTouch();
        }
        else
        {
            InputScrollByMouse();
        }
        Xaxis = Mathf.Clamp(Xaxis, rotateMin, rotateMax);

        targetRotation = Vector3.SmoothDamp(targetRotation, new Vector3(Xaxis, Yaxis), ref currentVel , smoothTime  ); 
        transform.eulerAngles = targetRotation;
    }
    public void InputScrollByTouch()
    {
        if (Input.touchCount > 0)
        {
            for (int i = 0; i < Input.touchCount; i++)
            {
                Touch touch = Input.GetTouch(i);
                if ((touch.position.x > Screen.width / 2)&& UIManager.instance.maybeClick)
                {
                    Yaxis += touch.deltaPosition.x * rotateSencitivity/15;
                    Xaxis -= touch.deltaPosition.y * rotateSencitivity/15;
                }
            }
        }
    }
    public void InputScrollByMouse()
    {
        if ((Input.mousePosition.x > Screen.width / 2) && UIManager.instance.maybeClick && Input.GetMouseButton(1))
        {
            Yaxis += Input.GetAxis("Mouse X") * rotateSencitivity;
            Xaxis -= Input.GetAxis("Mouse Y") * rotateSencitivity;
        }
    }
}
