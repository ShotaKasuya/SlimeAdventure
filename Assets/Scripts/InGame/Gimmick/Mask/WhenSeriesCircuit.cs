using System;
using System.Linq;
using InGame.Gimmick.Provider;
using InGame.Gimmick.Serializable;
using VContainer;

namespace InGame.Gimmick.Mask
{
    public class WhenSeriesCircuit : IEventMaskable
    {
        [Inject]
        public WhenSeriesCircuit(GimmickEventProvider eventProvider)
        {
            EventProvider = eventProvider;
        }

        public MaskedEventType Mask(GimmickEventInfo eventInfo)
        {
            switch (eventInfo.EventType)
            {
                case GimmickEventType.OnDeadBattery:
                    return MaskedEventType.OutOfCondition;
                case GimmickEventType.OnCharge:
                    if (EventProvider.EventInfos.All(x => x.EventType == GimmickEventType.OnCharge))
                    {
                        return MaskedEventType.InCondition;
                    }

                    return MaskedEventType.OutOfCondition;
                default:
                    throw new NotImplementedException();
            }
        }

        private GimmickEventProvider EventProvider { get; }
    }
}