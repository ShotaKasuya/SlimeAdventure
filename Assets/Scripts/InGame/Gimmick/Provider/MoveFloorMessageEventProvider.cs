using System;
using InGame.Interface;
using R3;
using VContainer;

namespace InGame.Gimmick.Provider
{
    public class MoveFloorMessageEventProvider : IMessageEventProvider
    {
        [Inject]
        public MoveFloorMessageEventProvider(GimmickEventProvider eventProvider, IEventMaskable eventMaskable)
        {
            MessageEventObservable = eventProvider.EventObservable
                .Select(eventMaskable.Mask)
                .Where(x => x != MaskedEventType.None)
                .DistinctUntilChanged()
                .Select(x =>
                {
                    return x switch
                    {
                        MaskedEventType.InCondition => new MessageEvent("床が動いた"),
                        MaskedEventType.OutOfCondition => new MessageEvent("床が止まった"),
                        _ => throw new NotImplementedException()
                    };
                });
        }

        public Observable<MessageEvent> MessageEventObservable { get; }
    }
}