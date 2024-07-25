using InGame.Item;
using KanKikuchi.AudioManager;
using UnityEngine;

namespace InGame.ScriptableObjects
{
    [CreateAssetMenu(fileName = "Item", menuName = "ScriptableObjects/Item")]
    public class ItemConstants : ScriptableObject
    {
        public ItemId ItemId => itemId;
        public ItemType ItemType => itemType;
        public float Power => power;
        public float TimeLen => timeLen;
        public string SePath => sePath;
        public Sprite ItemSprite => itemSprite;

        [SerializeField] private ItemId itemId;
        [SerializeField] private ItemType itemType;

        /// <summary>
        /// Barrier         => ダメージカット
        /// AtkUp           => 攻撃力上昇量
        /// Heal            => 回復量
        /// Regeneration    => 総回復量
        /// </summary>
        [SerializeField] private float power;

        /// <summary>
        /// Barrier,AtkUp,Regeneration => 持続時間
        /// Heal => _
        /// </summary>
        [SerializeField] private float timeLen;

        [SerializeField] [DropdownConstants(typeof(SEPath))]
        private string sePath;

        [SerializeField] private Sprite itemSprite;
    }
}