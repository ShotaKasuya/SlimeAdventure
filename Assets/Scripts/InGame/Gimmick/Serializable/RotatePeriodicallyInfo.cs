using System;
using System.Collections.Generic;
using InGame.Gimmick.View;
using UnityEngine;

namespace InGame.Gimmick.Serializable
{
    [Serializable]
    public class RotatePeriodicallyInfo
    {
        public GimmickViewBase RotateObject => rotateObject;
        public List<Vector3> RotationCursors => rotationCursors;
        public float RotationTime => rotationTime;
        public float Interval => interval;

        [SerializeField] private GimmickViewBase rotateObject;
        [SerializeField] private float rotationTime;
        [SerializeField] private float interval;
        [SerializeField] private List<Vector3> rotationCursors;
    }
}