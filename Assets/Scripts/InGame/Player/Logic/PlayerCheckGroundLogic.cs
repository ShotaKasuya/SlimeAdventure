using InGame.Player.Entity;
using InGame.Player.View;
using InGame.ScriptableObjects;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace InGame.Player.Logic
{
    public class PlayerCheckGroundLogic : ITickable
    {
        [Inject]
        public PlayerCheckGroundLogic(PlayerView playerView, ChildComponentView childComponentView,
            PlayerVelocityEntity velocityEntity,
            MutGroundEntity groundEntity, GroundRaycastInfo raycastInfo,
            MutPlayerStateEntity playerStateEntity)
        {
            PlayerView = playerView;
            ChildComponentView = childComponentView;
            Ground = groundEntity;
            RaycastInfo = raycastInfo;
            PlayerStateEntity = playerStateEntity;
            VelocityEntity = velocityEntity;
        }

        public void Tick()
        {
            if (Ground.IsGround.CurrentValue)
            {
                if (CheckGround()) return;

                Ground.MutIsGround.Value = false;

                return;
            }

            if (VelocityEntity.JumpVelocity >= 0) return;
            if (!CheckGround()) return;

            Ground.MutIsGround.Value = true;
            PlayerStateEntity.MutState.Value = PlayerStateType.Idle;
        }

        private bool CheckGround()
        {
            var from = ChildComponentView.GetGroundRaycastPos;
            var to = Vector3.down * RaycastInfo.RaycastDistance;

            var radius = PlayerView.PlayerSize.x / 3;
            var isHit = Physics.SphereCast(from, radius, Vector3.down,
                out var raycastHit, float.MaxValue, RaycastInfo.GroundLayerMask);

            Ground.RaycastHit = raycastHit;

            if (isHit)
            {
                Debug.DrawLine(from, raycastHit.point, Color.magenta, 10f); // 開始位置からヒット位置までの線
                Debug.DrawRay(raycastHit.point, raycastHit.normal, Color.yellow, 10f); // ヒット位置の法線
                Debug.DrawLine(raycastHit.point, raycastHit.point + Vector3.up * 0.1f, Color.red, 10f); // ヒット位置に小さな線 

                return raycastHit.distance < RaycastInfo.RaycastDistance;
            }
            else
            {
                Debug.DrawLine(from, from + to, Color.blue);
                return false;
            }
        }

        private MutGroundEntity Ground { get; }
        private ChildComponentView ChildComponentView { get; }
        private PlayerView PlayerView { get; }
        private GroundRaycastInfo RaycastInfo { get; }
        private MutPlayerStateEntity PlayerStateEntity { get; }
        private PlayerVelocityEntity VelocityEntity { get; }
    }
}