using System.Collections.Generic;
using System.Linq;
using InGame.Gimmick.Serializable;

namespace InGame.Gimmick.Entity
{
    public class EventHistoryEntity
    {
        public List<GimmickEventInfo> EventHistory { get; } = new List<GimmickEventInfo>();

        public void Add(GimmickEventInfo eventInfo)
        {
            if (EventHistory.Any(x => x == eventInfo))
            {
                return;
            }

            EventHistory.Add(eventInfo);
        }

        public void Remove(GimmickEventInfo eventInfo)
        {
            if (EventHistory.Any(x => x == eventInfo))
            {
                EventHistory.Remove(eventInfo);
            }
        }

        public bool IsSorted()
        {
            int before = -1;
            foreach (var eventInfo in EventHistory)
            {
                if (eventInfo.GimmickId > before)
                {
                    before = eventInfo.GimmickId;
                }
                else
                {
                    return false;
                }
            }

            return true;
        }

        public bool CheckLength(int length)
        {
            return length == EventHistory.Count;
        }
    }
}