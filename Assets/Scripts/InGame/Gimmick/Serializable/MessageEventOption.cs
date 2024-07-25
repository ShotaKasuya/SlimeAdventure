using System;
using UnityEngine;

namespace InGame.Gimmick.Serializable
{
    [Serializable]
    public class MessageEventOption
    {
        public bool ProvideMessage =>
            String.IsNullOrEmpty(inConditionMessage) & String.IsNullOrEmpty(outOfConditionMessage);

        public string InConditionMessage => inConditionMessage;
        public string OutOfConditionMessage => outOfConditionMessage;

        [SerializeField] private string inConditionMessage;
        [SerializeField] private string outOfConditionMessage;
    }
}