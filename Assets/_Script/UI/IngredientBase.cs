using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IngredientBase : ButtonInventory
{
    public override void ClickButton()
    {
        UIManager.instance.AddToItemList(item);
    }
}
