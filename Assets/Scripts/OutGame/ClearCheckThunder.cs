using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StaticVariables;

public class ClearCheckThunder : MonoBehaviour
{
    void Start()
    {

    }

    void Update()
    {

    }

    public void Clear()
    {
        StorySaver.TakadaiDungeonClear = true;
    }
}
