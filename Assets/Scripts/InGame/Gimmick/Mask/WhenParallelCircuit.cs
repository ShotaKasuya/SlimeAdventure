using System;
using System.Linq;
using InGame.Gimmick.Provider;
using InGame.Gimmick.Serializable;
using VContainer;

namespace InGame.Gimmick.Mask
{
    /// <summary>
    /// バッテリーがあるなら
    /// </summary>
    public class WhenParallelCircuit : IEventMaskable
    {
        [Inject]
        public WhenParallelCircuit(GimmickEventProvider eventProvider)
        {
            EventProvider = eventProvider;
        }

        public MaskedEventType Mask(GimmickEventInfo eventInfo)
        {
            switch (eventInfo.EventType)
            {
                case GimmickEventType.OnCharge:
                    return MaskedEventType.InCondition;
                case GimmickEventType.OnDeadBattery:
                    if (EventProvider.EventInfos.Any(x => x.EventType == GimmickEventType.OnCharge))
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