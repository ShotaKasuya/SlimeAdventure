using System;
using InGame.Interface;
using R3;
using UnityEngine;
using VContainer;

namespace InGame.Gimmick.Provider
{
    public class FallibleGimmickMessageEventProvider : IMessageEventProvider
    {
        [Inject]
        public FallibleGimmickMessageEventProvider(GimmickEventProvider eventProvider, IEventMaskable eventMaskable)
        {
            MessageEventObservable = eventProvider.EventObservable
                .Select(eventMaskable.Mask)
                .Where(x => x != MaskedEventType.None)
                .Select(x =>
                {
                    if (x == MaskedEventType.OutOfCondition)
                    {
                        Debug.Log("out of condition");
                    }

                    return x switch
                    {
                        MaskedEventType.InCondition => new MessageEvent("何かが動いた音がする"),
                        MaskedEventType.OutOfCondition => new MessageEvent("何かが間違っているようだ"),
                        _ => throw new NotImplementedException()
                    };
                }).AsObservable();
        }

        public Observable<MessageEvent> MessageEventObservable { get; }
    }
}