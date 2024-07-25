using System;
using UnityEngine;

namespace InGame.UserInterface.Serializable
{
    [Serializable]
    public class InteractIconConstant
    {
        public float FadeDuration => fadeDuration;
        public string ItemBoxMessage => itemBoxMessage;
        public string NoKeyMessage => noKeyMessage;
        public string HasKeyMessage => hasKeyMessage;

        [SerializeField] private float fadeDuration = 0.5f;
        [SerializeField] private string itemBoxMessage = "開ける";
        [SerializeField] private string noKeyMessage = "鍵が必要です";
        [SerializeField] private string hasKeyMessage = "鍵を使って開ける";
    }
}