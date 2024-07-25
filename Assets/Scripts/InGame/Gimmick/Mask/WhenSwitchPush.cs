using InGame.Gimmick.Serializable;

namespace InGame.Gimmick.Mask
{
    public class WhenSwitchPush : IEventMaskable
    {
        public MaskedEventType Mask(GimmickEventInfo eventInfo)
        {
            return eventInfo.EventType switch
            {
                GimmickEventType.OnSwitchTurnOn => MaskedEventType.InCondition,
                GimmickEventType.OnSwitchTurnOff => MaskedEventType.OutOfCondition,
                _ => MaskedEventType.None,
            };
        }
    }
}