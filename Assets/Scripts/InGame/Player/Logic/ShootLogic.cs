using InGame.Player.Container;
using InGame.Player.Entity;
using InGame.Player.View;
using InGame.ScriptableObjects;
using KanKikuchi.AudioManager;
using StaticVariables;
using UnityEngine;
using UnityEngine.InputSystem;
using VContainer;
using VContainer.Unity;

namespace InGame.Player.Logic
{
    public class ShootLogic : ITickable, ILateTickable, IInitializable
    {
        [Inject]
        public ShootLogic(PlayerView playerView, ChildComponentView childComponentView,
            PlayerInput playerInput, IBulletTypeReader bulletTypeReader, Bullets bullets,
            AttackStateEntity attackStateEntity)
        {
            PlayerView = playerView;
            ChildComponentView = childComponentView;
            ShootAction = playerInput.actions[InputDefinition.ShootAction];
            Bullets = bullets;
            BulletTypeReader = bulletTypeReader;
            AttackStateEntity = attackStateEntity;
        }

        public void Initialize()
        {
            PlayerContainer = PlayerView.GetComponent<LifetimeScope>();
        }

        public void Tick()
        {
            var currentInput = ReadShoot();
            if (!AttackStateEntity.IsOnInput(currentInput)) return;

            var instance = PlayerContainer.Container.Instantiate(GetBullet(),
                ChildComponentView.ShootPos, Quaternion.identity);
            var view = instance.Container.Resolve<BulletView>();
            view.ModelRigidbody.velocity = Bullets.ShootPower * CalcShootDirection();

            SEManager.Instance.Play(GetSe());
        }

        public void LateTick()
        {
            AttackStateEntity.AfterTick(ReadShoot());
        }

        private Vector3 CalcShootDirection()
        {
            return ChildComponentView.CameraTransform.forward;
        }

        private BulletContainer GetBullet()
        {
            return Bullets.GetBullet(BulletTypeReader.Reader.CurrentValue);
        }

        private string GetSe()
        {
            return Bullets.GetSe(BulletTypeReader.Reader.CurrentValue);
        }

        private bool ReadShoot()
        {
            return ShootAction.ReadValue<float>() > 0;
        }

        private PlayerView PlayerView { get; }
        private LifetimeScope PlayerContainer;
        private ChildComponentView ChildComponentView { get; }
        private IBulletTypeReader BulletTypeReader { get; }
        private InputAction ShootAction { get; }
        private Bullets Bullets { get; }
        private AttackStateEntity AttackStateEntity { get; }
    }
}