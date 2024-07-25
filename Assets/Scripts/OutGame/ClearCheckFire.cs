using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StaticVariables;

public class ClearCheckFire : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void Clear()
    {
        StorySaver.FirstDungeonClear = true;
    }
}
