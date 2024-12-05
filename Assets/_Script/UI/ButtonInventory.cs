using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonInventory : MonoBehaviour
{
    public IngredientDataSO item;
    public Button button;
    public void Awake()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(() => ClickButton());
    }
    public virtual void ClickButton()
    {

    }
    public virtual void SetItem(IngredientDataSO item)
    {
        this.item = item;
    }
}
