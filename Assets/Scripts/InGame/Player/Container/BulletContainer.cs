using InGame.Player.Logic;
using InGame.Player.View;
using InGame.ScriptableObjects;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace InGame.Player.Container
{
    public class BulletContainer : LifetimeScope
    {
        [SerializeField] private BulletView bulletView;
        [SerializeField] private BulletConstants info;

        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterComponent(bulletView);
            builder.RegisterInstance(info);

            // Entity


            // Logic
            builder.Register<BulletHitLogic>(Lifetime.Singleton);
        }

        private void Start()
        {
            Container.Resolve<BulletHitLogic>();
            // FIXME
            Destroy(gameObject, Container.Resolve<BulletConstants>().DestroyTime);
        }
    }
}