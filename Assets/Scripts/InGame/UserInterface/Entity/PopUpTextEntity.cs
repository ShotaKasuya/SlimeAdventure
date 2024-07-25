using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

namespace InGame.UserInterface.Entity
{
    public class PopUpTextEntity
    {
        private List<Transform> Transforms { get; } = new List<Transform>();
        public IReadOnlyList<Transform> ReadOnlyList => Transforms;

        public void AddText(Transform transform)
        {
            Transforms.Add(transform);
        }

        public void RemoveText(Transform transform)
        {
            transform.DOKill();
            Transforms.Remove(transform);
        }

        public void Scroll(float distance, float duration)
        {
            foreach (var transform in Transforms)
            {
                transform.DOLocalMoveY(distance, duration)
                    .SetRelative(true);
            }
        }
    }
}