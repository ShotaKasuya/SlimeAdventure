using System;
using InGame.Gimmick.Serializable;
using InGame.Interface;
using R3;
using VContainer;

namespace InGame.Gimmick.Provider
{
    public class DoorCameraEventProvider : ICameraEventProvider
    {
        [Inject]
        public DoorCameraEventProvider(GimmickEventProvider gimmickEventProvider, CameraEventOption eventOption
            , IEventMaskable eventMaskable)
        {
            if (!eventOption.ProvideCameraEvent) return;

            CameraEventObservable = gimmickEventProvider.EventObservable
                .Select(eventMaskable.Mask)
                .Where(x => x == MaskedEventType.InCondition)
                .DistinctUntilChanged()
                .Select(eventOption, (type, option) =>
                {
                    return type switch
                    {
                        MaskedEventType.InCondition => new CameraEvent(option.VirtualCamera, option.EventTime),
                        _ => throw new NotImplementedException()
                    };
                });
        }

        public Observable<CameraEvent> CameraEventObservable { get; }
    }
}