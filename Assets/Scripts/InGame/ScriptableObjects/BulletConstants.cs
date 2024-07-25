using UnityEngine;

namespace InGame.ScriptableObjects
{
    [CreateAssetMenu(fileName = "BulletStatus", menuName = "ScriptableObjects/BulletStatus")]
    public class BulletConstants : ScriptableObject
    {
        public BulletType BulletType => bulletType;
        public LayerMask InteractLayer => interactLayer;
        public int BasePower => basePower;
        public float DestroyTime => destroyTime;

        [SerializeField] private BulletType bulletType;
        [SerializeField] private LayerMask interactLayer;
        [SerializeField] private int basePower = 10;
        [SerializeField] private float destroyTime = 0.5f;
    }
}