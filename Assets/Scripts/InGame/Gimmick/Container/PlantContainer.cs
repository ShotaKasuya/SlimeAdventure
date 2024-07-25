using InGame.Gimmick.Container.Bases;
using InGame.Gimmick.Entity;
using InGame.Gimmick.Logic;
using InGame.Gimmick.Serializable;
using InGame.Gimmick.View;
using R3;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace InGame.Gimmick.Container
{
    public class PlantContainer : ChildGimmickContainerBase
    {
        [SerializeField] private PlantInfo info;
        [SerializeField] private BulletHittableView burnableObjectView;

        protected override void Configure(IContainerBuilder builder)
        {
            base.Configure(builder);
            builder.RegisterInstance(info);
            builder.RegisterInstance(new CompositeDisposable());
            builder.RegisterInstance(burnableObjectView).AsImplementedInterfaces().AsSelf();

            // Entity
            builder.Register<MutFireEntity>(Lifetime.Singleton).AsImplementedInterfaces().AsSelf();

            // Logic
            builder.RegisterEntryPoint<IgnitionLogic>();
            builder.Register<BurnOutLogic>(Lifetime.Singleton);
        }

        public void Start()
        {
            Container.Resolve<BurnOutLogic>();
        }
    }
}