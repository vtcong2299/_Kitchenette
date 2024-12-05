using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObj : MonoBehaviour
{
    [SerializeField]
    protected GameObject preFab;
    private GameObject posSpawn;
    private void Awake()
    {
        posSpawn = GameObject.Find("PosSpawnFood");
    }
    public virtual void Spawn()
    {
        if (GameManager.instance.hasFoodInHand)
        {
            return;
        }
        GameObject obj;
        obj = Instantiate(preFab);
        obj.transform.position = posSpawn.transform.position;
        obj.transform.parent = posSpawn.transform;
        GameManager.instance.foodSpawning=obj.GetComponent<FoodDataBase>().food ;
        GameManager.instance.hasFoodInHand = true;
    }
}
