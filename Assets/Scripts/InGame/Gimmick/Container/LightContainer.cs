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
    public class LightContainer : ChildGimmickContainerBase
    {
        [SerializeField] private BulletHittableView lightView;
        [SerializeField] private ChangeableMaterialObject particleObjects;

        protected override void Configure(IContainerBuilder builder)
        {
            base.Configure(builder);
            builder.RegisterInstance(lightView);
            builder.RegisterInstance(particleObjects);
            builder.RegisterInstance(new CompositeDisposable());

            builder.Register<MutFireEntity>(Lifetime.Scoped).AsImplementedInterfaces().AsSelf();

            builder.RegisterEntryPoint<IgnitionLogic>();
            builder.Register<LightVisualLogic>(Lifetime.Singleton);
        }

        private void Start()
        {
            Container.Resolve<LightVisualLogic>();
        }
    }
}