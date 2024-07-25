using InGame.Interface;
using R3;
using UnityEngine;

namespace InGame.SceneRoot.Provider
{
    public class CameraEventProvider : ICameraEventProvider, ICameraEventReceiver
    {
        public void AppendEvent(ICameraEventProvider cameraEventProvider, MonoBehaviour monoBehaviour)
        {
            cameraEventProvider?.CameraEventObservable?
                .Subscribe(Subject, (@event, subject) => { subject.OnNext(@event); }).AddTo(monoBehaviour);
        }

        private Subject<CameraEvent> Subject { get; } = new Subject<CameraEvent>();
        public Observable<CameraEvent> CameraEventObservable => Subject;
    }
}