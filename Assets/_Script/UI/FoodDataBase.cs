using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodDataBase : MonoBehaviour
{
    public FoodDataSO food;
    private void Update()
    {
        if (!GameManager.instance.hasFoodInHand)
        {
            Destroy(gameObject);
        }
    }
}
