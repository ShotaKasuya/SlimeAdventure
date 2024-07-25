using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;
using InGame.Interface;
using VContainer;
using StaticVariables;

[RequireComponent(typeof(Flowchart))]
public class PortalSystem : MonoBehaviour
{
    IStopEventReceiver EventReceiver;

    [Inject]
    public void Inject(IStopEventReceiver stopEventReceiver)
    {
        EventReceiver = stopEventReceiver;
    }

    GameObject playerObj;
    Flowchart flowChart;

    void Start()
    {
        playerObj = GameObject.FindGameObjectWithTag("Player");
        flowChart = GetComponent<Flowchart>();
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Talk();
        }
    }

    public void Talk()
    {
        var duration = 1f;
        EventReceiver.Publish(new StopEvent(StopEventType.StopUntilRestart, duration));

        if (StorySaver.FirstDungeonClear)
        {
            if (StorySaver.WaterSlimeClear)
            {
                if (StorySaver.TameikeDungeonClear) flowChart.SendFungusMessage("1");
                else flowChart.SendFungusMessage("2");
            }
            else flowChart.SendFungusMessage("3");
        }
        else flowChart.SendFungusMessage("4");
    }
}
