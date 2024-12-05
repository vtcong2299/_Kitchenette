using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnIceCreamSmall : SpawnObj
{
    public static SpawnIceCreamSmall instance;
    private void OnEnable()
    {
        instance = this;
    }
    private void OnDisable()
    {
        instance = null;
    }
}
