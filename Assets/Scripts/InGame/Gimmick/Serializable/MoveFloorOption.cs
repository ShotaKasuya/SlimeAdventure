using System;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

namespace InGame.Gimmick.Serializable
{
    [Serializable]
    public class MoveFloorOption
    {
        public bool DefaultMove => defaultMove;
        public IReadOnlyList<Transform> Positions => positions;
        public float BaseSpeed => baseSpeed;
        public Ease EaseType => easeType;
        public bool DoSnapping => doSnapping;
        public float Interval => interval;

        [SerializeField] private bool defaultMove;
        [SerializeField] private List<Transform> positions;
        [SerializeField] private float baseSpeed;
        [SerializeField] private Ease easeType;
        [SerializeField] private bool doSnapping;
        [SerializeField] private float interval;
    }
}