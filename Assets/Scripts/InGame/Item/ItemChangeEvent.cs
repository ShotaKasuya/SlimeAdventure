namespace InGame.Item
{
    public struct ItemChangeEvent
    {
        public ItemChangeEvent(ItemEventType eventType, ItemId itemId)
        {
            EventType = eventType;
            ItemId = itemId;
        }

        public ItemEventType EventType { get; }
        public ItemId ItemId { get; }
    }

    public enum ItemEventType
    {
        None,
        Get,
        Use,
    }
}