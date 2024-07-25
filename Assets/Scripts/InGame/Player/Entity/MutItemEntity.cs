using System.Collections.Generic;
using InGame.Item;
using R3;

namespace InGame.Player.Entity
{
    public class MutItemEntity : IItemReader
    {
        public MutItemEntity(CompositeDisposable disposable)
        {
            ReactiveItem = new Subject<ItemChangeEvent>();
            ItemCursor = new ReactiveProperty<int>();
            ItemList = new List<PlayerItem>();

            disposable.Add(ReactiveItem);
            disposable.Add(ItemCursor);
        }

        private ReactiveProperty<int> ItemCursor { get; }
        public List<PlayerItem> ItemList { get; set; }
        public ReadOnlyReactiveProperty<int> ItemCursorReader => ItemCursor;
        private Subject<ItemChangeEvent> ReactiveItem { get; }
        public Observable<ItemChangeEvent> ItemObservable => ReactiveItem;
        public IReadOnlyList<PlayerItem> ItemReader => ItemList;

        public void AddItem(ItemId itemId)
        {
            foreach (var item in ItemList)
            {
                if (item.Id == itemId)
                {
                    item.Inc();
                    ReactiveItem.OnNext(new ItemChangeEvent(ItemEventType.Get, itemId));
                    return;
                }
            }

            var addItem = new PlayerItem(itemId, 1);
            ItemList.Add(addItem);
            ReactiveItem.OnNext(new ItemChangeEvent(ItemEventType.Get, itemId));
        }

        public void SubItem(ItemId itemId)
        {
            foreach (var item in ItemList)
            {
                if (item.Id == itemId)
                {
                    item.Dec();
                    if (item.Count == 0)
                    {
                        ItemList.Remove(item);
                    }

                    ReactiveItem.OnNext(new ItemChangeEvent(ItemEventType.Use,  itemId));
                    return;
                }
            }
        }

        public void IncCursor()
        {
            if (ItemReader.Count == 0)
            {
                return;
            }
            if (ItemCursor.CurrentValue == ItemList.Count - 1)
            {
                ItemCursor.Value = 0;
                ReactiveItem.OnNext(new ItemChangeEvent());
                return;
            }

            ItemCursor.Value++;
            ReactiveItem.OnNext(new ItemChangeEvent(ItemEventType.None, ItemId.None));
        }

        public void DecCursor()
        {
            if (ItemReader.Count == 0)
            {
                return;
            }
            if (ItemCursor.CurrentValue == 0)
            {
                ItemCursor.Value = ItemList.Count - 1;
                ReactiveItem.OnNext(new ItemChangeEvent());
                return;
            }

            ItemCursor.Value--;
            ReactiveItem.OnNext(new ItemChangeEvent(ItemEventType.None, ItemId.None));
        }
    }
}