using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "itemData", menuName = "Item")]
public class IngredientDataSO : ScriptableObject
{
    public int id;
    public string itemName;
    public Sprite image;
}
