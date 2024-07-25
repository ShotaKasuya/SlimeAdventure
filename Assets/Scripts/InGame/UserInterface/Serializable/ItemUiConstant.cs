using System;
using InGame.ScriptableObjects;
using UnityEngine;

namespace InGame.UserInterface.Serializable
{
    [Serializable]
    public class ItemUiConstant
    {
        public ItemDb ItemDb => itemDb;
        public float SequenceTime => sequenceTime;

        [SerializeField] private ItemDb itemDb;
        [SerializeField] private float sequenceTime;
    }
}