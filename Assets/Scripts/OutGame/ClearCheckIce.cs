using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StaticVariables;

public class ClearCheckIce : MonoBehaviour
{
    void Start()
    {

    }

    void Update()
    {

    }

    public void Clear()
    {
        StorySaver.TameikeDungeonClear = true;
    }
}
