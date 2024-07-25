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
    public class DoorContainer : ParentGimmickContainerBase
    {
        [SerializeField] private ChildGimmickContainers gimmickContainers;
        [SerializeField] private MovePosition2 movePositions;
        [SerializeField] private InteractableGimmickView door;

        protected override void Configure(IContainerBuilder builder)
        {
            base.Configure(builder);
            builder.RegisterInstance(door).AsImplementedInterfaces().AsSelf();
            builder.RegisterInstance(movePositions);
            builder.RegisterInstance(new CompositeDisposable());
            builder.RegisterInstance(gimmickContainers);

            builder.RegisterEntryPoint<GimmickEventProvider>().As<GimmickEventProvider, IStartable>();

            builder.Register<DoorOpenLogic>(Lifetime.Singleton);
            builder.Register<Interact2GimmickEventLogic>(Lifetime.Singleton).AsImplementedInterfaces().AsSelf();

            if (eventMaskType == EventMaskType.BurnedInOrder)
            {
                builder.Register<IMessageEventProvider, FallibleGimmickMessageEventProvider>(Lifetime.Singleton);
            }
            else
            {
                builder.Register<IMessageEventProvider, DoorMessageEventProvider>(Lifetime.Singleton);
            }

            builder.Register<ICameraEventProvider, DoorCameraEventProvider>(Lifetime.Singleton);
        }

        private void Start()
        {
            base.Start();
            Container.Resolve<GimmickEventProvider>();
            Container.Resolve<Interact2GimmickEventLogic>();
            Container.Resolve<DoorOpenLogic>();
        }
    }
}