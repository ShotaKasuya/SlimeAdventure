using System;
using UnityEngine;
using UnityEngine.UI;

namespace InGame.UserInterface.Serializable
{
    [Serializable]
    public class PopUpTextConstant
    {
        public Text TextPrefab => textPrefab;
        public float FadeDuration => fadeDuration;
        public float TimeToLive => timeToLive;

        [SerializeField] private Text textPrefab;
        [SerializeField] private float fadeDuration;
        [SerializeField] private float timeToLive;
    }
}