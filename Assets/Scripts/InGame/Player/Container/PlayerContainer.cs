using InGame.Player.Entity;
using InGame.Player.Logic;
using InGame.Player.View;
using InGame.ScriptableObjects;
using UnityEngine;
using UnityEngine.InputSystem;
using VContainer;
using VContainer.Unity;

namespace InGame.Player.Container
{
    public class PlayerContainer : LifetimeScope
    {
        [SerializeField] private PlayerInput playerInput;
        [SerializeField] private ChildComponentView childComponentView;
        [SerializeField] private PlayerView playerView;
        [SerializeField] private PlayerConstants playerConstants;
        [SerializeField] private FollowPlayer miniMapCamera;

        protected override void Configure(IContainerBuilder builder)
        {
            Debug.Log("Hello World");
            builder.RegisterComponent(playerView);
            builder.RegisterComponent(playerInput);
            builder.RegisterComponent(childComponentView);
            builder.RegisterInstance(playerConstants.HpConstant);
            builder.RegisterInstance(playerConstants.JumpConstant);
            builder.RegisterInstance(playerConstants.CameraConstant);
            builder.RegisterInstance(playerConstants.MoveSpeedConstant);
            builder.RegisterInstance(playerConstants.RaycastInfo);
            builder.RegisterInstance(playerConstants.Bullets);
            builder.RegisterInstance(playerConstants.ShootInfo);
            builder.RegisterInstance(playerConstants.PlayerLookConstant);

            // Entity
            builder.Register<MutBulletEntity>(Lifetime.Singleton).As<MutBulletEntity, IBulletTypeReader>();
            builder.Register<MutPlayerHpEntity>(Lifetime.Singleton).As<MutPlayerHpEntity, IHpReader>();
            builder.Register<MutGroundEntity>(Lifetime.Singleton).As<MutGroundEntity, IGroundReader>();
            builder.Register<MutPlayerStateEntity>(Lifetime.Singleton).As<MutPlayerStateEntity, IPlayerStateReader>();
            builder.Register<AttackStateEntity>(Lifetime.Singleton);

            // Logic
            builder.UseEntryPoints(pointsBuilder =>
            {
                pointsBuilder.Add<ShootLogic>();
                pointsBuilder.Add<ChangeBulletTypeLogic>();
                pointsBuilder.Add<PlayerMoveLogic>();
                pointsBuilder.Add<PlayerJumpLogic>();
                pointsBuilder.Add<PlayerCheckGroundLogic>();
                pointsBuilder.Add<CameraRotationLogic>();
                pointsBuilder.Add<EscapeGameLogic>();
            });
        }

        private void Start()
        {
            var map = Container.Instantiate(miniMapCamera);
            map.Init(transform);
        }
    }
}