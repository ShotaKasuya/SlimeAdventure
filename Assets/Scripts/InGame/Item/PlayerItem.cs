
using MessagePack;

namespace InGame.Item
{
    [MessagePackObject]
    public class PlayerItem
    {
        [Key(1)]
        public ItemId Id { get; }
        [Key(2)]
        public int Count { get; private set; }

        public void Inc()
        {
            Count++;
        }

        public void Dec()
        {
            Count--;
        }

        public PlayerItem(ItemId id, int count)
        {
            Id = id;
            Count = count;
        }
    }
}