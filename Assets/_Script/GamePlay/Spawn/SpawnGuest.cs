using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnGuest : MonoBehaviour
{
    public static SpawnGuest instance;
    [SerializeField]
    private GameObject guestPrefab;
    [SerializeField]
    private Transform posSpawnGuest;
    [SerializeField]
    private float timeDelaySpawn = 10;
    public float timeSpawn = 0;
    private void OnEnable()
    {
        instance = this;
    }
    private void OnDisable()
    {
        instance = null;
    }
    private void Update()
    {
        Spawn();
    }
    public void Spawn()
    {
        if (GameManager.instance.posNotHasGuest.Count == 0)
        {
            timeSpawn = 0;
            return;
        }
        timeSpawn += Time.deltaTime;
        if (timeSpawn < timeDelaySpawn)
        {
            return;
        }
        SpawnObject();
    }
    public void SpawnObject()
    {
        GameObject obj;
        obj = Instantiate(guestPrefab, posSpawnGuest);
        obj.transform.position = posSpawnGuest.position;
        timeSpawn = 0;
    }
}
