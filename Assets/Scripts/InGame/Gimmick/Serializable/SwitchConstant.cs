using System;
using UnityEngine;

namespace InGame.Gimmick.Serializable
{
    [Serializable]
    public class SwitchConstant
    {
        public float Distance => distance;
        public Vector3 CastCube => castCube;
        public LayerMask TargetLayer => targetLayer;
        public bool IsOnlyOnce => isOnlyOnce;
        public float DefaultPosY => defaultPosY;
        public float PushDownPosY => pushDownPosY;
        public float SwitchPushTime => switchPushTime;

        [SerializeField] private float distance;
        [SerializeField] private Vector3 castCube;
        [SerializeField] private LayerMask targetLayer;

        [SerializeField] private bool isOnlyOnce;
        [SerializeField] private float defaultPosY;
        [SerializeField] private float pushDownPosY;
        [SerializeField] private float switchPushTime;
    }
}