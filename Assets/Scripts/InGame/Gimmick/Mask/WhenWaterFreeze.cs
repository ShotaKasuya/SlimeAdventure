using InGame.Gimmick.Serializable;

namespace InGame.Gimmick.Mask
{
    public class WhenWaterFreeze : IEventMaskable
    {
        public MaskedEventType Mask(GimmickEventInfo eventInfo)
        {
            return eventInfo.EventType switch
            {
                GimmickEventType.OnWaterFreezes => MaskedEventType.InCondition,
                GimmickEventType.OnIceMelt => MaskedEventType.OutOfCondition,
                _ => MaskedEventType.None,
            };
        }
    }
}