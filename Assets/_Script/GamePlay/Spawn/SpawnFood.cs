using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnFood : SpawnObj
{
    public static SpawnFood instance;
    [SerializeField]
    private GameObject khoaiTayPrefab;
    [SerializeField]
    private GameObject chickenPrefab;
    [SerializeField]
    private GameObject ramenPrefab;
    [SerializeField]
    private GameObject pizzaPrefab;
    [SerializeField]
    private GameObject hamburgerPrefab;
    private void OnEnable()
    {
        instance = this;
    }
    private void OnDisable()
    {
        instance = null;
    }
    public void SetPrefab()
    {
        switch (GameManager.instance.idFood)
        {
            case 0:
                {
                    preFab = hamburgerPrefab;
                    break;
                }
            case 1:
                {
                    preFab = pizzaPrefab;
                    break;
                }
            case 2:
                {
                    preFab = ramenPrefab;
                    break;
                }
            case 3:
                {
                    preFab = khoaiTayPrefab;
                    break;
                }
            case 4:
                {
                    preFab = chickenPrefab;
                    break;
                }
            case -1:
                {
                    preFab = null;
                    break;
                }
        }
    }
}


