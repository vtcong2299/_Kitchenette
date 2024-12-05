using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    [SerializeField]
    private List<IngredientDataSO> itemsList = new List<IngredientDataSO>();
    [SerializeField]
    private List<IngredientDataSO> cookList = new List<IngredientDataSO>();
    [SerializeField]
    private List<FoodDataSO> foodList = new List<FoodDataSO>();
    [SerializeField]
    private GameObject panelFridgeTop;
    [SerializeField]
    private GameObject panelFridgeBot;
    [SerializeField]
    private GameObject panelPlayerBag;
    [SerializeField]
    private GameObject panelMenuVendingMachine;
    [SerializeField]
    private GameObject panelMenuCafeMachine;
    [SerializeField]
    private GameObject panelPauseGame;
    [SerializeField]
    private GameObject panelEndGame;
    [SerializeField]
    private GameObject joystick;
    [SerializeField]
    private GameObject panelCook;
    [SerializeField]
    private Transform itemInBag;
    [SerializeField]
    private Transform itemInStove;
    [SerializeField]
    private Transform posFood;
    [SerializeField]
    private GameObject itemInBagPrefab;
    [SerializeField]
    private GameObject itemInStovePrefab;
    [SerializeField]
    private GameObject foodPrefab;
    [SerializeField]
    private GameObject panelRecipeMenu;
    [SerializeField]
    private GameObject back;
    [SerializeField]
    private Text txtMoney;
    [SerializeField]
    private Text txtFPS;
    [SerializeField]
    private Text timeCountDown;
    [SerializeField]
    private Text txtMoneyEndGame;
    public bool maybeClick;
    public bool playerMaybeMove;
    public bool isJoystick;
    private int maxList = 6;

    private void OnEnable()
    {
        instance = this;
    }
    private void OnDisable()
    {
        instance = null;
    }
    private void Awake()
    {
        SetAllPanelFalse();
    }
    private void Update()
    {
        if (isJoystick)
        {
            joystick.SetActive(true);
        }
        else
        {
            joystick.SetActive(false);
        }
        CheckPlayerMaybeMove();        
    }
    public void PressButtonBack()
    {
        SetAllPanelFalse();
    }
    public void SetAllPanelFalse()
    {
        maybeClick = true;
        panelFridgeBot.SetActive(false);
        panelFridgeTop.SetActive(false);
        panelPlayerBag.SetActive(false);
        panelMenuVendingMachine.SetActive(false);
        panelMenuCafeMachine.SetActive(false);
        panelCook.SetActive(false);
        panelRecipeMenu.SetActive(false);
        back.SetActive(false);
    }
    public void SpawnCoffeButton()
    {
        SoundManager.instance.SoundSpawnCoffe();
        SpawnCoffe.instance.Spawn();
        SetAllPanelFalse();
    }
    public void SpawnCocaButton()
    {
        SoundManager.instance.SoundSpawnCoffe();
        SpawnCoca.instance.Spawn();
        SetAllPanelFalse();
    } 
    public void SpawnSmallIceCreamButton()
    {
        SoundManager.instance.SoundSpawnFood();
        SpawnIceCreamSmall.instance.Spawn();
        SetAllPanelFalse();
    }
    public void SpawnBigIceCreamButton()
    {
        SoundManager.instance.SoundSpawnFood();
        SpawnIceCreamBig.instance.Spawn();
        SetAllPanelFalse();
    }
    public void SpawnFoodButton()
    {
        SoundManager.instance.SoundSpawnFood();
        SpawnFood.instance.Spawn();
        cookList.Clear();
        GameManager.instance.newList.Clear();
        foodList.Clear();
        AddItemToStove();
        SetAllPanelFalse();
    }
    public void AddToItemList(IngredientDataSO item)
    {
        if (itemsList.Count < maxList)
        {
            itemsList.Add(item);
            AddItemToBag();
        }
    }
    public void AddToCookList(IngredientDataSO item)
    {
        if (cookList.Count < maxList && panelCook.activeSelf)
        {
            cookList.Add(item);
            GameManager.instance.newList.Add(item.id);
            AddItemToStove();
            GameManager.instance.CheckFood();
        }
    }
    public void AddItemToBag()
    {
        int i = 0;
        foreach (Transform item in itemInBag)
        {
            Destroy(item.gameObject);
        }
        foreach (IngredientDataSO item in itemsList)
        {
            GameObject obj = Instantiate(itemInBagPrefab, itemInBag);
            obj.GetComponent<RectTransform>().anchoredPosition = new Vector2(42 + i * 70, 0);
            obj.GetComponent<IngredientInBag>().SetItem(item);
            var itemImage = obj.GetComponent<Image>();
            itemImage.sprite = item.image;
            i++;
        }
    }
    public void AddItemToStove()
    {
        int j = 0;
        foreach (Transform item in itemInStove)
        {
            Destroy(item.gameObject);
        }
        foreach (IngredientDataSO item in cookList)
        {
            GameObject obj = Instantiate(itemInStovePrefab, itemInStove);
            obj.GetComponent<RectTransform>().anchoredPosition = new Vector2(-270 + j * 108, -91);
            obj.GetComponent<Cooking>().SetItem(item);
            var itemImage = obj.GetComponent<Image>();
            itemImage.sprite = item.image;
            j++;
        }
    }
    public void AddToFoodList(FoodDataSO food)
    {
        if (foodList.Count < 1)
        {
            foodList.Add(food);
            AddFood();
        }
    }
    public void AddFood()
    {
        foreach (Transform food in posFood)
        {
            Destroy(food.gameObject);
        }
        foreach (FoodDataSO food in foodList)
        {
            GameObject obj = Instantiate(foodPrefab, posFood);
            obj.GetComponent<Food>().SetFood(food);
            var itemImage = obj.GetComponent<Image>();
            itemImage.sprite = food.image;
        }
    }
    public void RemoveItemList(IngredientDataSO item)
    {
        itemsList.Remove(item);
    }
    public void RemoveCookList(IngredientDataSO item)
    {
        cookList.Remove(item);
    }
    public void RemoveFoodList(FoodDataSO food)
    {
        foodList.Remove(food);
    }
    public void RemoveNewList(IngredientDataSO item)
    {
        GameManager.instance.newList.Remove(item.id);
        GameManager.instance.CheckFood();
    }
    public void OnClickMenu(GameObject panelMenu)
    {
        if ((((Input.mousePosition.x > Screen.width / 4) || (Input.mousePosition.y > Screen.height / 2))
            && isJoystick && maybeClick) || (!isJoystick && maybeClick))
        {
            panelMenu.SetActive(true);
            panelPlayerBag.SetActive(true);
            back.SetActive(true);
            maybeClick = false;
        }
    }
    public void OnClickFridge(GameObject panelMenu)
    {
        panelMenu.SetActive(true);
        panelPlayerBag.SetActive(true);
        maybeClick = false;
    }
    public void OnClickRecipeMenu()
    {
        if (panelRecipeMenu.activeSelf)
        {
            panelRecipeMenu.SetActive(false);
            maybeClick = true;
        }
        else
        {
            panelRecipeMenu.SetActive(true);
            maybeClick = false;
        }
    }
    public void OnClickIngredientCookButton(IngredientDataSO item)
    {
        AddToItemList(item);
        RemoveCookList(item);
        RemoveNewList(item);
    }
    public void OnClickPauseButton()
    {
        panelPauseGame.SetActive(true);
        maybeClick = false ;
        Time.timeScale = 0;
    }
    public void OnClickResumeButton()
    {
        panelPauseGame.SetActive(false);
        maybeClick = true;
        Time.timeScale = 1;
    }
    public void OnClickRestartButton()
    {
        GameManager.instance.RestartGame();
        maybeClick = true;
    }
    public void OnClickHomeButton()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }
    public void CheckPlayerMaybeMove()
    {
        if (panelFridgeTop.activeSelf||panelFridgeBot.activeSelf||panelCook.activeSelf||panelMenuCafeMachine.activeSelf
            || panelMenuVendingMachine.activeSelf || panelRecipeMenu.activeSelf)
        {
            playerMaybeMove = false;
        }
        else
        {
            playerMaybeMove = true;
        }
    }
    public void OnChangeMoneyUI(int money)
    {
        txtMoney.text = money.ToString();
    }
    public void EndGameMoneyUI()
    {
        txtMoneyEndGame.text = GameManager.instance.money.ToString();
    }
    public void OnChangeFPS(int fps)
    {
        txtFPS.text = "FPS: " + fps;
    }
    public void OnChangTimeCountDown(int minutes, int seconds)
    {
        timeCountDown.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
    public void EndGame()
    {
        panelEndGame.SetActive(true);
        maybeClick =false;
        SetAllPanelFalse();
        EndGameMoneyUI();
        Time.timeScale = 0;
    }
    public void ReloadSetupUI()
    {
        itemsList.Clear();
        cookList.Clear();
        foodList.Clear();
        AddItemToBag();
        AddItemToStove();
        AddFood();
        panelPauseGame.SetActive(false);
        panelEndGame.SetActive(false );
    }
}
