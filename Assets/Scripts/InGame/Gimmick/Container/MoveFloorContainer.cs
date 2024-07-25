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
    public class MoveFloorContainer : ParentGimmickContainerBase
    {
        [SerializeField] private GimmickViewBase targetFloor;
        [SerializeField] private MoveFloorOption floorOption;
        [SerializeField] private ChildGimmickContainers gimmickContainerBases;

        protected override void Configure(IContainerBuilder builder)
        {
            base.Configure(builder);
            builder.RegisterInstance(floorOption);
            builder.RegisterInstance(targetFloor);
            builder.RegisterInstance(gimmickContainerBases);
            builder.RegisterInstance(new CompositeDisposable());

            builder.RegisterEntryPoint<GimmickEventProvider>().As<GimmickEventProvider, IStartable>();

            builder.RegisterEntryPoint<FloorMoveLogic>();
            builder.Register<MoveWithObjectLogic>(Lifetime.Singleton);
            if (eventMaskType == EventMaskType.BurnedInOrder)
            {
                builder.Register<IMessageEventProvider, FallibleGimmickMessageEventProvider>(Lifetime.Singleton);
            }
            else
            {
                builder.Register<IMessageEventProvider, MoveFloorMessageEventProvider>(Lifetime.Singleton);
            }

            builder.Register<ICameraEventProvider, EmptyCameraEventProvider>(Lifetime.Singleton);
        }

        private void Start()
        {
            base.Start();
            Container.Resolve<MoveWithObjectLogic>();
        }
    }
}