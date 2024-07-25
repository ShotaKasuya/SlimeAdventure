using InGame.Gimmick.Container.Bases;
using InGame.Gimmick.Entity;
using InGame.Gimmick.Logic;
using InGame.Gimmick.Serializable;
using InGame.Gimmick.View;
using InGame.ScriptableObjects;
using R3;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace InGame.Gimmick.Container
{
    public class BatteryContainer : ChildGimmickContainerBase
    {
        [SerializeField] private BulletHittableView view;
        [SerializeField] private ChangeableMaterialObject particleObjects;
        [SerializeField] private BatteryInfo batteryInfo;

        protected override void Configure(IContainerBuilder builder)
        {
            base.Configure(builder);
            var disposable = new CompositeDisposable();
            disposable.AddTo(this);
            builder.RegisterInstance(view).AsImplementedInterfaces().AsSelf();
            builder.RegisterInstance(batteryInfo);
            builder.RegisterInstance(particleObjects);
            builder.RegisterInstance(disposable);

            builder.Register<MutBatteryEntity>(Lifetime.Singleton).AsImplementedInterfaces().AsSelf();

            builder.UseEntryPoints(pointsBuilder =>
            {
                pointsBuilder.Add<BatteryDecreaseLogic>();
                pointsBuilder.Add<ChargeBatteryLogic>();
            });

            builder.Register<BatteryVisualLogic>(Lifetime.Singleton);
        }

        private void Start()
        {
            Container.Resolve<BatteryVisualLogic>();
        }
    }
}