using System.Linq;
using InGame.Gimmick.Provider;
using InGame.Gimmick.Serializable;
using VContainer;

namespace InGame.Gimmick.Mask
{
    /// <summary>
    /// 全ての明かりがともったら
    /// </summary>
    public class WhenAllLightBurn : IEventMaskable
    {
        [Inject]
        public WhenAllLightBurn(GimmickEventProvider eventProvider)
        {
            GimmickEventProvider = eventProvider;
        }


        public MaskedEventType Mask(GimmickEventInfo eventInfo)
        {
            switch (eventInfo.EventType)
            {
                case GimmickEventType.OnBurn:
                    if (GimmickEventProvider.EventInfos.All(x => x.EventType == GimmickEventType.OnBurn))
                    {
                        return MaskedEventType.InCondition;
                    }

                    break;
                case GimmickEventType.OnExtinguish:
                    return MaskedEventType.OutOfCondition;
            }

            return MaskedEventType.None;
        }

        private GimmickEventProvider GimmickEventProvider { get; }
    }
}