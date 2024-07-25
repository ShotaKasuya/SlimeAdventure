using System;
using UnityEngine;

namespace InGame.UserInterface.Serializable
{
    [Serializable]
    public class HpGageUiConstant
    {
        public float Duration => duration;

        [SerializeField] private float duration;
    }
}