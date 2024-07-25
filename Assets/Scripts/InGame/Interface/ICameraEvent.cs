using Cinemachine;
using R3;
using UnityEngine;

namespace InGame.Interface
{
    public interface ICameraEventProvider
    {
        Observable<CameraEvent> CameraEventObservable { get; }
    }
    
    public interface ICameraEventReceiver
    {
        public void AppendEvent(ICameraEventProvider cameraEventProvider, MonoBehaviour monoBehaviour);
    }

    public struct CameraEvent
    {
        public CameraEvent(CinemachineVirtualCamera virtualCamera, float duration)
        {
            VirtualCamera = virtualCamera;
            Duration = duration;
        }

        public CinemachineVirtualCamera VirtualCamera { get; }
        public float Duration { get; }
    }
}