using System;
using DG.Tweening;
using R3;
using R3.Triggers;
using UnityEngine;

namespace InGame.Gimmick.View
{
    /// <summary>
    /// Monoからイベントを購読する際はAwakeを待ってください
    /// </summary>
    public class GimmickViewBase : MonoBehaviour, IDisposable
    {
        public Observable<Collision> OnCollisionEnter => this.OnCollisionEnterAsObservable();
        public Observable<Collision> OnCollisionExit => this.OnCollisionExitAsObservable();
        public Transform ModelTransform { get; private set; }

        private void Awake()
        {
            ModelTransform = transform;
        }

        public void Dispose()
        {
            ModelTransform.DOKill();
        }
    }
}