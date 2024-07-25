using InGame.Gimmick.Entity;
using InGame.Gimmick.Serializable;
using VContainer;

namespace InGame.Gimmick.Mask
{
    public class WhenInOrder : IEventMaskable
    {
        [Inject]
        public WhenInOrder(ChildGimmickContainers childGimmickContainers, EventHistoryEntity eventHistory)
        {
            GimmickContainers = childGimmickContainers;
            EventHistory = eventHistory;
        }

        public MaskedEventType Mask(GimmickEventInfo eventInfo)
        {
            if (eventInfo.EventType != GimmickEventType.OnBurn)
            {
                if (eventInfo.EventType == GimmickEventType.OnExtinguish)
                {
                    EventHistory.Remove(new GimmickEventInfo(GimmickEventType.OnBurn, eventInfo.GimmickId));
                }

                return MaskedEventType.None;
            }

            EventHistory.Add(eventInfo);
            if (!EventHistory.CheckLength(GimmickContainers.GimmickContainers.Count)) return MaskedEventType.None;
            if (EventHistory.IsSorted())
            {
                return MaskedEventType.InCondition;
            }

            return MaskedEventType.OutOfCondition;
        }

        private ChildGimmickContainers GimmickContainers { get; }
        private EventHistoryEntity EventHistory { get; }
    }
}