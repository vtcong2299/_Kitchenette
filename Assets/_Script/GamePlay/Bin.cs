using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bin : MonoBehaviour
{
    public void OnMouseDown()
    {
        if (Vector3.Distance(transform.position, GameManager.instance.player.position) > GameManager.instance.distance)
        {
            return;
        }
        GameManager.instance.hasFoodInHand = false;
    }
}
