using InGame.Interface;
using R3;
using UnityEngine;

namespace InGame.SceneRoot.Provider
{
    public class StopEventProvider:IStopEventProvider, IStopEventReceiver
    {
        private Subject<StopEvent> Subject { get; } = new Subject<StopEvent>();
        public Observable<StopEvent> StopEventObservable => Subject;
        public void Publish(StopEvent stopEvent)
        {
            Subject.OnNext(stopEvent);
        }

        public void AppendEvent(IStopEventProvider playerStopEventProvider, MonoBehaviour monoBehaviour)
        {
            playerStopEventProvider.StopEventObservable
                .Subscribe(Subject.OnNext)
                .AddTo(monoBehaviour);
        }
    }
}