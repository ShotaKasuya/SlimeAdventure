using InGame.Player.Entity;
using InGame.Player.Logic;
using InGame.Player.Provider;
using InGame.Player.View;
using InGame.ScriptableObjects;
using R3;
using UnityEngine;
using UnityEngine.InputSystem;
using VContainer;
using VContainer.Unity;

namespace InGame.Player.Container
{
    [RequireComponent(typeof(PlayerInput))]
    [RequireComponent(typeof(Animator))]
    public class Player3PContainer : PlayerContainerBase
    {
        [SerializeField] private PlayerInput playerInput;
        [SerializeField] private ChildComponentView childComponentView;
        [SerializeField] private PlayerView playerView;
        [SerializeField] private PlayerConstants playerConstants;
        [SerializeField] private FollowPlayer miniMapCamera;

        protected override void Configure(IContainerBuilder builder)
        {
            base.Configure(builder);

            builder.RegisterComponent(playerView);
            builder.RegisterComponent(playerInput);
            builder.RegisterComponent(childComponentView);
            builder.RegisterComponent(GetComponent<Animator>());
            builder.RegisterInstance(new CompositeDisposable());
            builder.RegisterInstance(playerConstants.HpConstant);
            builder.RegisterInstance(playerConstants.JumpConstant);
            builder.RegisterInstance(playerConstants.CameraConstant);
            builder.RegisterInstance(playerConstants.MoveSpeedConstant);
            builder.RegisterInstance(playerConstants.RaycastInfo);
            builder.RegisterInstance(playerConstants.Bullets);
            builder.RegisterInstance(playerConstants.ShootInfo);
            builder.RegisterInstance(playerConstants.PlayerLookConstant);
            builder.RegisterInstance(playerConstants.ItemUseConstant);

            // Entity
            builder.Register<MutBulletEntity>(Lifetime.Singleton).AsImplementedInterfaces().AsSelf();
            builder.Register<MutPlayerHpEntity>(Lifetime.Singleton).AsImplementedInterfaces().AsSelf();
            builder.Register<MutGroundEntity>(Lifetime.Singleton).AsImplementedInterfaces().AsSelf();
            builder.Register<MutPlayerStateEntity>(Lifetime.Singleton).AsImplementedInterfaces().AsSelf();
            builder.Register<MutItemEntity>(Lifetime.Singleton).AsImplementedInterfaces().AsSelf();
            builder.Register<MutInteractableEntity>(Lifetime.Singleton).AsImplementedInterfaces().AsSelf();
            builder.Register<PlayerVelocityEntity>(Lifetime.Singleton);
            builder.Register<AttackStateEntity>(Lifetime.Singleton);

            // Logic
            builder.UseEntryPoints(pointsBuilder =>
            {
                pointsBuilder.Add<ShootLogic>();
                pointsBuilder.Add<PlayerMoveLogic>();
                pointsBuilder.Add<PlayerCheckGroundLogic>();
                pointsBuilder.Add<CameraRotationLogic>();
                pointsBuilder.Add<EscapeGameLogic>();
                pointsBuilder.Add<AnimatorManageLogic>();
                pointsBuilder.Add<SearchInteractableLogic>();
                pointsBuilder.Add<ApplyVelocityLogic>();
                pointsBuilder.Add<GravityLogic>();
            });
            builder.Register<ChangeBulletTypeLogic>(Lifetime.Singleton);
            builder.Register<PlayerJumpLogic>(Lifetime.Singleton);
            builder.Register<ItemChangeLogic>(Lifetime.Singleton);
            builder.Register<InteractLogic>(Lifetime.Singleton);
            builder.Register<PlayerSaveLogic>(Lifetime.Singleton).AsImplementedInterfaces();
            builder.Register<PlayerLoadLogic>(Lifetime.Singleton).AsImplementedInterfaces();
            builder.Register<PlayerStopLogic>(Lifetime.Singleton).AsImplementedInterfaces();
            builder.Register<GetItemLogic>(Lifetime.Singleton);
            builder.Register<PlayerMessageEventProvider>(Lifetime.Singleton).AsImplementedInterfaces();
            builder.Register<InteractableLogLogic>(Lifetime.Singleton);
        }

        private void Start()
        {
            Container.Resolve<ChangeBulletTypeLogic>();
            Container.Resolve<PlayerJumpLogic>();
            Container.Resolve<ItemChangeLogic>();
            Container.Resolve<InteractLogic>();
            Container.Resolve<GetItemLogic>();
            Container.Resolve<InteractableLogLogic>();
            var map = Container.Instantiate(miniMapCamera);
            map.Init(transform);
        }
    }
}