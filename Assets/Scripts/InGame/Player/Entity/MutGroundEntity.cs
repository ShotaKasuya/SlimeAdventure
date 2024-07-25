using InGame.ScriptableObjects;
using R3;
using UnityEngine;

namespace InGame.Player.Entity
{
    public class MutGroundEntity : IGroundReader
    {
        public MutGroundEntity(GroundRaycastInfo raycastInfo)
        {
            MutIsGround = new ReactiveProperty<bool>();
        }

        public int RaycastHitNum => HitNum;
        public int HitNum;

        /// <summary>
        /// この変数はTickで更新されるので使うならPostTick以降で
        /// </summary>
        public RaycastHit RaycastHit { get; set; }

        public ReactiveProperty<bool> MutIsGround { get; }
        public ReadOnlyReactiveProperty<bool> IsGround => MutIsGround;
    }
}