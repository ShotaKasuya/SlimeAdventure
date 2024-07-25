using System;
using InGame.Interface;
using InGame.Item;
using R3;
using UnityEngine;

namespace InGame.Gimmick.View
{
    public class InteractableGimmickView : GimmickViewBase, IInteractable, IDisposable
    {
        [SerializeField] private InteractType interactType;
        [SerializeField] private ItemId requestItem;

        private Subject<InteractInfo> InteractEvent { get; } = new Subject<InteractInfo>();
        public Observable<InteractInfo> InteractObservable => InteractEvent;
        public bool NowInteractable { get; private set; } = true;
        public InteractType Type => interactType;
        public ItemId RequestItem => requestItem;

        public void OnInteract(InteractInfo interactInfo)
        {
            NowInteractable = false;
            InteractEvent.OnNext(interactInfo);
        }

        public void Dispose()
        {
            InteractEvent.Dispose();
        }
    }
}