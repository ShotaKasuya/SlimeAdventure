using InGame.Interface;
using R3;

namespace InGame.Gimmick.Provider
{
    public class EmptyCameraEventProvider : ICameraEventProvider
    {
        public Observable<CameraEvent> CameraEventObservable => null;
    }
}