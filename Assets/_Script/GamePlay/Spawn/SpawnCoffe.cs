using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCoffe : SpawnObj
{
    public static SpawnCoffe instance;
    private void OnEnable()
    {
        instance = this;
    }
    private void OnDisable()
    {
        instance = null;
    }

}
