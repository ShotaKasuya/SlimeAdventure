using InGame.Interface;
using UnityEngine;

namespace InGame.Item
{
    public class ItemComponent : MonoBehaviour, IGettableItem
    {
        [SerializeField] private ItemId itemId;
        public ItemId ItemId => itemId;
    }
}