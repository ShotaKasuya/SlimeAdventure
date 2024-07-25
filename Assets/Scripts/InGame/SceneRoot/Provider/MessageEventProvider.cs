using InGame.Interface;
using R3;
using UnityEngine;

namespace InGame.SceneRoot.Provider
{
    /// <summary>
    /// FIXME?: 同じようなクラスが複数できる。
    /// 再利用のできるかも?
    /// </summary>
    public class MessageEventProvider : IMessageEventProvider, IMessageEventReceiver
    {
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