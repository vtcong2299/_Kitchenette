using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "foodData", menuName = "Food")]
public class FoodDataSO : ScriptableObject
{
    public int id;
    public string foodName;
    public int price;
    public List<int> recipe;
    public Sprite image;
}

