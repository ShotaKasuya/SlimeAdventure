using System.Linq;
using InGame.Gimmick.Provider;
using InGame.Gimmick.Serializable;
using VContainer;

namespace InGame.Gimmick.Mask
{
    public class WhenAllSwitchOn : IEventMaskable
    {
        [Inject]
        public WhenAllSwitchOn(GimmickEventProvider eventProvider)
        {
            EventProvider = eventProvider;
        }

        public MaskedEventType Mask(GimmickEventInfo eventInfo)
        {
            switch (eventInfo.EventType)
            {
                case GimmickEventType.OnSwitchTurnOn:
                    if (EventProvider.EventInfos.All(x => x.EventType == GimmickEventType.OnSwitchTurnOn))
                    {
                        return MaskedEventType.InCondition;
                    }

                    break;
                case GimmickEventType.OnSwitchTurnOff:
                    return MaskedEventType.OutOfCondition;
            }

            return MaskedEventType.None;
        }

        private GimmickEventProvider EventProvider { get; }
    }
}