using DG.Tweening;
using InGame.Gimmick.Provider;
using InGame.Gimmick.Serializable;
using R3;
using VContainer;

namespace InGame.Gimmick.Logic
{
    public class DoorOpenLogic
    {
        [Inject]
        public DoorOpenLogic(GimmickEventProvider eventProvider, IEventMaskable eventMask,
            MovePosition2 movePosition2, CompositeDisposable disposable)
        {
            movePosition2.MoveTarget.position = movePosition2.Positions.before;
            eventProvider.EventObservable.Select(eventMask.Mask).Subscribe(movePosition2, (type, positions) =>
                {
                    switch (type)
                    {
                        case MaskedEventType.InCondition:
                            positions.MoveTarget.DOMove(positions.Positions.after, positions.MoveTime)
                                .SetEase(positions.Ease);
                            break;
                        case MaskedEventType.OutOfCondition:
                            positions.MoveTarget.DOMove(positions.Positions.before, positions.MoveTime)
                                .SetEase(positions.Ease);
                            break;
                    }
                }
            ).AddTo(disposable);
        }
    }
}