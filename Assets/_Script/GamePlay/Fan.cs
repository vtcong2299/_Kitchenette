using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fan : MonoBehaviour
{
    public float fanSpeed = 5f;
    public float angle = 0f;
    private void Update()
    {
        FanMove();
    }
    public void FanMove()
    {
        angle += Time.deltaTime * fanSpeed;
        transform.rotation =  Quaternion.Euler(0, angle, 0);
    }
}
