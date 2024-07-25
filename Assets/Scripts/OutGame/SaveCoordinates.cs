using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InGame.SceneRoot.Logic;
using VContainer;
using InGame.Player;

public class SaveCoordinates : MonoBehaviour
{
    SaveLogic Logic;

    [Inject]
    public void Inject(SaveLogic saveLogic)
    {
        Logic = saveLogic;
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void PlayerSave() 
    {
        Logic.Save();
    }
}
