using System;

namespace InGame.Gimmick.Serializable
{
    public struct GimmickEventInfo
    {
        public GimmickEventInfo(GimmickEventType eventType, int gimmickId)
        {
            EventType = eventType;
            GimmickId = gimmickId;
        }

        public GimmickEventType EventType { get; }
        public int GimmickId { get; }

        public static bool operator ==(GimmickEventInfo lhs, GimmickEventInfo rhs)
        {
            return (lhs.GimmickId == rhs.GimmickId) && (lhs.EventType == rhs.EventType);
        }

        public static bool operator !=(GimmickEventInfo lhs, GimmickEventInfo rhs)
        {
            return !((lhs.GimmickId == rhs.GimmickId) && (lhs.EventType == rhs.EventType));
        }

        public bool Equals(GimmickEventInfo other)
        {
            return EventType == other.EventType && GimmickId == other.GimmickId;
        }

        public override bool Equals(object obj)
        {
            return obj is GimmickEventInfo other && Equals(other);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine((int)EventType, GimmickId);
        }
    }
}