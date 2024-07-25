using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;
using InGame.ScriptableObjects;
using SceneTransition;

public class SceneTransrationSystem : MonoBehaviour
{
    [SerializeField] private SceneDefinition sceneDefinition;

    public void Start()
    {

    }

    void Update()
    {

    }
    
    public void OnButton()
    {
        ChangeScene();
    }

    public void ChangeScene()
    {
        SceneSequencer.Sequencer.SceneLoad(sceneDefinition);
    }
}