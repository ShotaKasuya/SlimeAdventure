using System;
using InGame.Interface;
using InGame.Item;
using InGame.SceneRoot;
using R3;
using UnityEngine;

namespace InGame.Player.Provider
{
    public class PlayerMessageEventProvider : IMessageEventProvider, IMessageEventReceiver
    {
        public PlayerMessageEventProvider(IItemReader itemReader,
            CompositeDisposable disposable)
        {
            disposable.Add(Subject);
            itemReader.ItemObservable.Where(x => x.EventType != ItemEventType.None).Subscribe(x =>
            {
                var message = x.EventType switch
                {
                    ItemEventType.Get => new MessageEvent($"{x.ItemId}を取得した"),
                    ItemEventType.Use => new MessageEvent($"{x.ItemId}を使用した"),
                    _ => throw new NotImplementedException()
                };
                Subject.OnNext(message);
            }).AddTo(disposable);
        }

        public void Publish(MessageEvent messageEvent)
        {
            Subject.OnNext(messageEvent);
        }

        public void AppendEvent(IMessageEventProvider messageEventProvider, MonoBehaviour monoBehaviour)
        {
            messageEventProvider?.MessageEventObservable?.Subscribe(x => Subject.OnNext(x)).AddTo(monoBehaviour);
        }

        private Subject<MessageEvent> Subject { get; } = new Subject<MessageEvent>();
        public Observable<MessageEvent> MessageEventObservable => Subject;
    }
}