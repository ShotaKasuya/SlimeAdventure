using InGame.Gimmick.Serializable;

namespace InGame.Gimmick.Mask
{
    /// <summary>
    /// 火が灯ったら
    /// </summary>
    public class WhenFireBurn : IEventMaskable
    {
        public MaskedEventType Mask(GimmickEventInfo eventInfo)
        {
            return eventInfo.EventType switch
            {
                GimmickEventType.OnBurn => MaskedEventType.InCondition,
                GimmickEventType.OnExtinguish => MaskedEventType.OutOfCondition,
                _ => MaskedEventType.None
            };
        }
    }
}