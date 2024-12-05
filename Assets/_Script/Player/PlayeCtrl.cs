using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayeCtrl : MonoBehaviour
{
    private Rigidbody rb;
    private float pressVertical;
    private float pressHorizontal;
    [SerializeField]
    private float speedPlayer = 2.5f;
    [SerializeField]
    private float speedPlayerRotate = 5f;
    [SerializeField]
    private Vector3 moveDirection;
    [SerializeField]
    private GameObject playerCamera;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        PlayerMove();
    }
    private void Update()
    {
        if (UIManager.instance.isJoystick)
        {
            JoystickMoveInput();
        }
        else
        {
            PcMoveInput();
        }
    }
    public void PcMoveInput()
    {
        this.pressVertical = Input.GetAxis("Vertical");
        this.pressHorizontal = Input.GetAxis("Horizontal");
    }
    public void JoystickMoveInput()
    {
        this.pressVertical = Joystick.instance.Vertical();
        this.pressHorizontal = Joystick.instance.Horizontal();
    }

    public void PlayerMove()
    {
        if(!UIManager.instance.playerMaybeMove)
        {
            PlayerAnimation.instance.SetIsRunFalse();
            return;
        }
        Vector3 movement1 = playerCamera.transform.forward * pressVertical;
        Vector3 movement2 = playerCamera.transform.right * pressHorizontal;
        moveDirection = movement1 + movement2;
        moveDirection.y = 0;
        rb.MovePosition(rb.position + this.speedPlayer * moveDirection * Time.deltaTime);
        if (moveDirection != Vector3.zero)
        {
            PlayerAnimation.instance.SetIsRunTrue();
            Quaternion targetRotation = Quaternion.LookRotation(moveDirection);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * speedPlayerRotate);
        }
        else
        {
            PlayerAnimation.instance.SetIsRunFalse();
        }
    }    
}
