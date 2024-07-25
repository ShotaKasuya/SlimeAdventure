using System;
using DG.Tweening;
using UnityEngine;

namespace InGame.Gimmick.Serializable
{
    [Serializable]
    public class MovePosition2
    {
        public Transform MoveTarget => targetTransform;
        public (Vector3 before, Vector3 after) Positions => (before.position, after.position);
        public float MoveTime => moveTime;
        public Ease Ease => ease;

        [SerializeField] private Transform targetTransform;
        [SerializeField] private Transform before;
        [SerializeField] private Transform after;
        [SerializeField] private float moveTime;
        [SerializeField] private Ease ease;
    }
}