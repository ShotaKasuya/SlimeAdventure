using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InGame.Interface;
using VContainer;

public class Remove : MonoBehaviour
{
    IStopEventReceiver EventReceiver;

    [Inject]
    public void Inject(IStopEventReceiver stopEventReceiver)
    {
        EventReceiver = stopEventReceiver;
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void Move()
    {
        var duration = 1f;
        EventReceiver.Publish(new StopEvent(StopEventType.Restart, duration));
    }
}
