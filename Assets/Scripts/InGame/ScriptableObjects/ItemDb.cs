using System.Collections.Generic;
using EditorExtension;
using UnityEngine;

namespace InGame.ScriptableObjects
{
    [CreateAssetMenu(fileName = "ItemDataBase", menuName = "ScriptableObjects/ItemDb")]
    public class ItemDb : SortableScriptableObject
    {
        public IReadOnlyList<ItemConstants> Items => items;

        [SerializeField] private List<ItemConstants> items;


        public override void Sort()
        {
            items.Sort((constants1, constants2) => constants1.ItemId.CompareTo(constants2.ItemId));
        }
    }
}