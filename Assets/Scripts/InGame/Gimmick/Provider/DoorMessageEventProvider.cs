using System;
using InGame.Interface;
using R3;
using VContainer;

namespace InGame.Gimmick.Provider
{
    public class DoorMessageEventProvider : IMessageEventProvider
    {
        [Inject]
        public DoorMessageEventProvider(GimmickEventProvider eventProvider, IEventMaskable eventMaskable)
        {
            MessageEventObservable = eventProvider.EventObservable
                .Select(eventMaskable.Mask)
                .Where(x => x != MaskedEventType.None)
                .DistinctUntilChanged()
                .Select(x =>
                {
                    return x switch
                    {
                        MaskedEventType.InCondition => new MessageEvent("ドアが開いた"),
                        MaskedEventType.OutOfCondition => new MessageEvent("ドアが閉じた"),
                        _ => throw new NotImplementedException()
                    };
                });
        }

        public Observable<MessageEvent> MessageEventObservable { get; }
    }
}