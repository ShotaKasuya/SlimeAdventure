using InGame.Gimmick.Serializable;

namespace InGame.Gimmick.Mask
{
    public class WhenUsedKey : IEventMaskable
    {
        public MaskedEventType Mask(GimmickEventInfo eventInfo)
        {
            return eventInfo.EventType switch
            {
                GimmickEventType.OnUsedKey => MaskedEventType.InCondition,
                _ => MaskedEventType.None,
            };
        }
    }
}