using System;
using InGame.Gimmick.Serializable;
using InGame.Interface;
using R3;
using VContainer;

namespace InGame.Gimmick.Provider
{
    public class GimmickMessageEventProvider : IMessageEventProvider
    {
        [Inject]
        public GimmickMessageEventProvider(GimmickEventProvider eventProvider,
            IEventMaskable eventMaskable, MessageEventOption eventOption)
        {
            if (!eventOption.ProvideMessage)
            {
                MessageEventObservable = null;
                return;
            }

            MessageEventObservable = eventProvider
                .EventObservable
                .Select(eventMaskable.Mask)
                .Where(x => x != MaskedEventType.None)
                .Select(eventOption, (type, option) =>
                {
                    return type switch
                    {
                        MaskedEventType.InCondition => new MessageEvent(option.InConditionMessage),
                        MaskedEventType.OutOfCondition => new MessageEvent(option.OutOfConditionMessage),
                        _ => throw new NotImplementedException()
                    };
                });
        }

        public Observable<MessageEvent> MessageEventObservable { get; }
    }
}