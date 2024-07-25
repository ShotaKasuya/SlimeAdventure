using System;
using UnityEngine;

namespace InGame.ScriptableObjects
{
    [Serializable]
    public class BatteryInfo
    {
        public float BatteryMax => batteryMax;
        public float BatteryDecreaseSpeed => batteryDecreaseSpeed;

        [SerializeField] private float batteryMax;
        [SerializeField] private float batteryDecreaseSpeed;
    }
}