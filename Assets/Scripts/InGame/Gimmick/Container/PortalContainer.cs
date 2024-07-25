using InGame.Gimmick.Container.Bases;
using InGame.Gimmick.Logic;
using InGame.Gimmick.Provider;
using InGame.Gimmick.Serializable;
using InGame.Gimmick.View;
using InGame.Interface;
using R3;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace InGame.Gimmick.Container
{
    public class PortalContainer : ParentGimmickContainerBase
    {
        [SerializeField] private ChildGimmickContainers gimmickContainers;

        protected override void Configure(IContainerBuilder builder)
        {
            base.Configure(builder);
            builder.RegisterInstance(GetComponent<GimmickViewBase>());
            builder.RegisterInstance(new CompositeDisposable());
            builder.RegisterInstance(gimmickContainers);

            builder.RegisterEntryPoint<GimmickEventProvider>().As<GimmickEventProvider, IStartable>();

            builder.Register<ActivationLogic>(Lifetime.Singleton);
            builder.Register<ICameraEventProvider, EmptyCameraEventProvider>(Lifetime.Singleton);
        }

        private void Start()
        {
            Container.Resolve<ActivationLogic>();
        }
    }
}