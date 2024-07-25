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
    [RequireComponent(typeof(GimmickViewBase))]
    public class SwitchContainer : ChildGimmickContainerBase
    {
        [SerializeField] private SwitchConstant switchConstant;

        protected override void Configure(IContainerBuilder builder)
        {
            base.Configure(builder);
            builder.RegisterInstance(new CompositeDisposable());
            builder.RegisterInstance(switchConstant);
            builder.RegisterComponent(GetComponent<GimmickViewBase>());

            builder.Register<MutSwitchEntity>(Lifetime.Singleton).AsImplementedInterfaces().AsSelf();

            builder.Register<SwitchMoveLogic>(Lifetime.Singleton);
            builder.RegisterEntryPoint<CheckPlayerTakingOverLogic>();
        }

        private void Start()
        {
            Container.Resolve<SwitchMoveLogic>();
        }
    }
}