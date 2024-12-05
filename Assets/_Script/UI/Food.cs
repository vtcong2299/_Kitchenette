using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Food : MonoBehaviour
{
    [SerializeField]
    private FoodDataSO food;
    private Button button;
    private void Awake()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(() => ClickCookButton());
    }
    public void SetFood(FoodDataSO food)
    {
        this.food = food;
    }
    public void ClickCookButton() 
    {
        if (GameManager.instance.hasFoodInHand)
        {
            return;
        }
        UIManager.instance.SpawnFoodButton();
        Destroy(gameObject);
    }
}
