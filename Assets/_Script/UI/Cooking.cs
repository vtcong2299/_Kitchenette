using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cooking : ButtonInventory
{
    public override void ClickButton()
    {
        UIManager.instance.OnClickIngredientCookButton(item);
        Destroy(gameObject);
    }
}
