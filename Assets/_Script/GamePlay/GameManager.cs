using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public List<GameObject> posNotHasGuest = new List<GameObject>();
    public List<FoodDataSO> foodDataList = new List<FoodDataSO>();
    private List<List<int>> recipes = new List<List<int>>();
    public List<int> newList = new List<int>();
    public FoodDataSO foodSpawning;
    public Transform player;
    public Transform PosTargetSpawnGuest;
    public Transform SpawnGuestPos;
    [SerializeField]
    private int fps = 0;
    [SerializeField]
    private float timeDelayUpdatePfs = 0f;
    public float timePlayGame = 300;
    public float distance = 2f;
    public int money = 0;
    public int idFood;
    public bool isTouch;
    public bool hasFoodInHand;
    private void OnEnable()
    {
        instance = this;
    }
    private void OnDisable()
    {
        instance = null;
    }
    public void Awake()
    {
        foreach (FoodDataSO food in foodDataList)
        {
            recipes.Add(food.recipe);
        }
    }
    private void Start()
    {
        RestartGame();
        SoundManager.instance.StartSoundManager();
    }
    private void Update()
    {
        if (timePlayGame <= 0)
        {
            UIManager.instance.EndGame();
        }

        CaculateFPS();
    }
    private void FixedUpdate()
    {
        CountDownTimePlayGame();
    }
    public void CheckFood()
    {
        foreach (FoodDataSO food in foodDataList)
        {
            if (food.recipe == IsMatchWithAnyList(newList, recipes))
            {
                idFood = food.id;
                UIManager.instance.AddToFoodList(food);
                SpawnFood.instance.SetPrefab();
                return;
            }
            else
            {
                idFood = -1;
                UIManager.instance.RemoveFoodList(food);
                UIManager.instance.AddFood();
            }
        }
    }
    public List<int> IsMatchWithAnyList(List<int> newList, List<List<int>> recipes)
    {
        HashSet<int> newSet = new HashSet<int>(newList);

        foreach (var recipe in recipes)
        {
            HashSet<int> m = new HashSet<int>(recipe);
            if (newSet.SetEquals(m))
                return recipe;
        }
        return null;
    }
    public void ChangeListPos(int index)
    {
        posNotHasGuest.Remove(posNotHasGuest[index]);
    }
    public void OnChangeMoney()
    {
        UIManager.instance.OnChangeMoneyUI(money);
    }
    public void CaculateFPS()
    {
        fps = (int)(1 / Time.unscaledDeltaTime);
        timeDelayUpdatePfs += Time.unscaledDeltaTime;
        if (timeDelayUpdatePfs >= 0.3f)
        {
            UIManager.instance.OnChangeFPS(fps);
            timeDelayUpdatePfs = 0f;
        }
    }
    public void CountDownTimePlayGame()
    {
        timePlayGame -= Time.deltaTime;
        if (timePlayGame <= 0)
        {
            timePlayGame = 0;
        }
        int minutes = Mathf.FloorToInt(timePlayGame / 60);
        int seconds = Mathf.FloorToInt(timePlayGame % 60);
        UIManager.instance.OnChangTimeCountDown(minutes, seconds);
    }
    public void ReloadSetup()
    {
        UIManager.instance.ReloadSetupUI();
        foreach (Transform guest in SpawnGuestPos)
        {
            Destroy(guest.gameObject);
        }
        posNotHasGuest.Clear();
        foreach (Transform obj in PosTargetSpawnGuest)
        {
            posNotHasGuest.Add(obj.gameObject);
        }
        timePlayGame = 300;
        SpawnGuest.instance.timeSpawn = 0;
        money = 0;
        UIManager.instance.OnChangeMoneyUI(money);
        Time.timeScale = 1;
    }
    public void RestartGame()
    {
        ReloadSetup();
        SpawnGuest.instance.SpawnObject();
    }
    public void OnClickGuest(FoodDataSO food, GameObject targetPos)
    {
        money += food.price;
        SoundManager.instance.SoundMoney();
        OnChangeMoney();
        hasFoodInHand = false;
        posNotHasGuest.Add(targetPos);
    }
}
