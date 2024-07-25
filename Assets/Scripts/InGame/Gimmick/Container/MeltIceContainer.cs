using InGame.Gimmick.Entity;
using InGame.Gimmick.Logic;
using InGame.Gimmick.Serializable;
using InGame.Gimmick.View;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace InGame.Gimmick.Container
{
    [RequireComponent(typeof(BulletHittableView))]
    public class MeltIceContainer : LifetimeScope
    {
        [SerializeField] private MeltIceConstant meltIceConstant;

        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterInstance(meltIceConstant);
            builder.RegisterComponent(GetComponent<BulletHittableView>());

            builder.Register<MutIceAmountEntity>(Lifetime.Singleton).AsImplementedInterfaces().AsSelf();

            builder.Register<SizeChangeLogic>(Lifetime.Singleton);
            builder.Register<IceMeltLogic>(Lifetime.Singleton);
        }

        private void Start()
        {
            Container.Resolve<SizeChangeLogic>();
            Container.Resolve<IceMeltLogic>();
        }
    }
}