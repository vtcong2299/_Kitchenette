using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuOnClick : MonoBehaviour
{
    [SerializeField]
    private GameObject panelMenu;
    void OnMouseDown()
    {
        if (Vector3.Distance(transform.position, GameManager.instance.player.position)> GameManager.instance.distance)
        {
            return;
        }
        UIManager.instance.OnClickMenu(panelMenu);
    }    
}
