using R3;
using UnityEngine;

namespace InGame.Interface
{
    public interface IMessageEventProvider
    {
        public Observable<MessageEvent> MessageEventObservable { get; }
    }

    public interface IMessageEventReceiver
    {
        public void Publish(MessageEvent messageEvent);
        public void AppendEvent(IMessageEventProvider messageEventProvider, MonoBehaviour monoBehaviour);
    }
    
    public struct MessageEvent
    {
        public string Description { get; }

        public MessageEvent(string description)
        {
            Description = description;
        }
    }
}