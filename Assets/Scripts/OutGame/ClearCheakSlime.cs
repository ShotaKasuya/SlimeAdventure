using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StaticVariables;

public class ClearCheckSlime : MonoBehaviour
{
    void Start()
    {

    }

    void Update()
    {

    }

    public void Clear()
    {
        StorySaver.WaterSlimeClear = true;
    }
}

