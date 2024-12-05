using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RotateOnClick : MonoBehaviour
{
    [SerializeField]
    private float rotationSpeed = 2.0f;
    private Quaternion originalRotation; // Lưu trữ góc quay ban đầu
    private Quaternion rotatedRotation; // Lưu trữ góc quay sau khi xoay
    [SerializeField]
    private Vector3 angle ;
    [SerializeField]
    private GameObject panelMenu;
    void Awake()
    {
        originalRotation = transform.rotation;
        rotatedRotation = Quaternion.Euler(transform.eulerAngles + angle);
    }
    void OnMouseDown()
    {
        if (Vector3.Distance(transform.position, GameManager.instance.player.position) > GameManager.instance.distance)
        {
            return;
        }
        if ((((Input.mousePosition.x > Screen.width / 4) || (Input.mousePosition.y > Screen.height / 2)) && UIManager.instance.isJoystick 
            && UIManager.instance.maybeClick) || (!UIManager.instance.isJoystick && UIManager.instance.maybeClick))
        {
            StartCoroutine(RotateObject());
        }
    }
    IEnumerator RotateObject()
    {
        Quaternion startRotation = transform.rotation;
        Quaternion endRotation = rotatedRotation;
        float elapsedTime = 0f;
        SoundManager.instance.SoundOpenDoor();

        while (elapsedTime < 1f / rotationSpeed)
        {
            transform.rotation = Quaternion.Slerp(startRotation, endRotation, elapsedTime * rotationSpeed);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        UIManager.instance.OnClickFridge(panelMenu);
    }
    public void PressBackButton()
    {
        StartCoroutine(ReRotateObject());
    }
    IEnumerator ReRotateObject()
    {
        Quaternion startRotation = transform.rotation;
        Quaternion endRotation = originalRotation;
        float elapsedTime = 0f;
        UIManager.instance.PressButtonBack();
        while (elapsedTime < 1f / rotationSpeed)
        {
            transform.rotation = Quaternion.Slerp(startRotation, endRotation, elapsedTime * rotationSpeed);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        SoundManager.instance.SoundCloseDoor();
    }
}







