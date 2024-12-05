using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class IngredientInBag : ButtonInventory
{
    public override void ClickButton()
    {
        UIManager.instance.RemoveItemList(item);
        UIManager.instance.AddToCookList(item);
        Destroy(gameObject);
    }
}
