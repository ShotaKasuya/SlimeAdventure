using R3;
using UnityEngine;

namespace InGame.Interface
{
    public interface IStopEventProvider
    {
        Observable<StopEvent> StopEventObservable { get; }
    }

    public interface IStopEventReceiver
    {
        public void Publish(StopEvent stopEvent);
        public void AppendEvent(IStopEventProvider playerStopEventProvider, MonoBehaviour monoBehaviour);
    }

    public enum StopEventType
    {
        StopForSeconds,
        StopUntilRestart,
        Restart,
    }

    public struct StopEvent
    {
        public StopEvent(StopEventType eventType , float stopTime)
        {
            EventType = eventType;
            StopTime = stopTime;
        }
        
        public StopEventType EventType { get; }
        public float StopTime { get; }
    }
}