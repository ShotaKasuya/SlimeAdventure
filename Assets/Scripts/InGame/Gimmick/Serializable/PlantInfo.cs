using System;
using UnityEngine;

namespace InGame.Gimmick.Serializable
{
    [Serializable]
    public class PlantInfo
    {
        public float BurnOutTime => burnOutTime;

        [SerializeField] private float burnOutTime;
    }
}