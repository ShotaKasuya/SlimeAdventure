using InGame.Gimmick.Entity;
using InGame.Gimmick.Logic;
using InGame.Gimmick.Serializable;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace InGame.Gimmick.Container
{
    public class RotationObjectContainer : LifetimeScope
    {
        [SerializeField] private RotatePeriodicallyInfo rotationInfo;

        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterInstance(rotationInfo);

            builder.Register<StoppableSequenceEntity>(Lifetime.Singleton);

            builder.Register<RotatePeriodicallyLogic>(Lifetime.Singleton);
        }

        private void Start()
        {
            Container.Resolve<RotatePeriodicallyLogic>();
        }
    }
}