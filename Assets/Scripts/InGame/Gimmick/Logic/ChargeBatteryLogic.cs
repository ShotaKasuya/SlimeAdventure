using InGame.Gimmick.Entity;
using InGame.Gimmick.View;
using R3;
using VContainer;
using VContainer.Unity;

namespace InGame.Gimmick.Logic
{
    public class ChargeBatteryLogic : IStartable
    {
        [Inject]
        public ChargeBatteryLogic(BulletHittableView hittableView, MutBatteryEntity batteryEntity)
        {
            HittableView = hittableView;
            BatteryEntity = batteryEntity;
        }

        public void Start()
        {
            HittableView.HitObservable.Subscribe(BatteryEntity, (info, entity) =>
            {
                switch (info.BulletType)
                {
                    case BulletType.Bolt:
                        entity.AddEnergy(info.Power);
                        break;
                }
            });
        }

        private BulletHittableView HittableView { get; }
        private MutBatteryEntity BatteryEntity { get; }
    }
}