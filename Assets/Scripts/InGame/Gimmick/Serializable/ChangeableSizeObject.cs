using System;
using DG.Tweening;
using UnityEngine;

namespace InGame.Gimmick.Serializable
{
    [Serializable]
    public class ChangeableSizeObject
    {
        [SerializeField] private Transform targetObject;
        [SerializeField] private Vector3 beforeSize = new Vector3(1, 1, 1);
        [SerializeField] private Vector3 afterSize = new Vector3(2, 2, 2);
        [SerializeField] private float duration;

        public void Change()
        {
            targetObject.DOScale(afterSize, duration);
        }

        public void Reset()
        {
            targetObject.DOScale(beforeSize, duration);
        }
    }
}