using System;
using System.Linq;
using DG.Tweening;
using InGame.Gimmick.Provider;
using InGame.Gimmick.Serializable;
using InGame.Gimmick.View;
using R3;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace InGame.Gimmick.Logic
{
    public class FloorMoveLogic : IStartable, IDisposable
    {
        [Inject]
        public FloorMoveLogic(GimmickViewBase targetFloor, GimmickEventProvider eventProvider,
            MoveFloorOption moveFloorOption, IEventMaskable eventMaskable, CompositeDisposable disposable)
        {
            Sequence = DOTween.Sequence();
            TargetFloor = targetFloor;
            EventProvider = eventProvider;
            MoveFloorOption = moveFloorOption;
            EventMaskable = eventMaskable;
            Disposable = disposable;
        }

        public void Start()
        {
            var posCache = TargetFloor.ModelTransform.position;
            foreach (var position in MoveFloorOption.Positions.Select(x => x.position))
            {
                var duration = (posCache - position).magnitude / MoveFloorOption.BaseSpeed;
                Sequence.Append(
                        TargetFloor.ModelTransform.DOMove(position, duration, MoveFloorOption.DoSnapping))
                    .AppendInterval(MoveFloorOption.Interval);
                posCache = position;
            }

            Sequence.SetLoops(-1, LoopType.Restart);
            if (!MoveFloorOption.DefaultMove)
            {
                Sequence.Pause();
            }

            EventProvider.EventObservable.Select(EventMaskable.Mask)
                .Subscribe(type =>
                {
                    Debug.Log("called");
                    switch (type)
                    {
                        case MaskedEventType.InCondition:
                            Sequence.Play();
                            break;
                        case MaskedEventType.OutOfCondition:
                            Sequence.Pause();
                            break;
                    }
                }).AddTo(Disposable);
        }

        public void Dispose()
        {
            Sequence.Kill();
        }

        private Sequence Sequence { get; }
        private GimmickViewBase TargetFloor { get; }
        private GimmickEventProvider EventProvider { get; }
        private IEventMaskable EventMaskable { get; }
        private MoveFloorOption MoveFloorOption { get; }
        private CompositeDisposable Disposable { get; }
    }
}