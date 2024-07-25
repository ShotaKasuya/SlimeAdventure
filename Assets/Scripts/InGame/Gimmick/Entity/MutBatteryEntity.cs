using InGame.Gimmick.Serializable;
using InGame.ScriptableObjects;
using R3;
using VContainer;

namespace InGame.Gimmick.Entity
{
    public class MutBatteryEntity : IBatteryReader
    {
        [Inject]
        public MutBatteryEntity(GimmickId gimmickId, BatteryInfo batteryInfo, CompositeDisposable disposable)
        {
            BatteryInfo = batteryInfo;
            GimmickId = gimmickId;
            Mut = new ReactiveProperty<BatteryType>();
            disposable.Add(Mut);
        }

        public void AddEnergy(float addAmount)
        {
            _energyAmount += addAmount;
            Mut.Value = BatteryType.SomeEnergy;
            if (EnergyAmount >= BatteryInfo.BatteryMax)
            {
                _energyAmount = BatteryInfo.BatteryMax;
            }
        }

        public void SubEnergy(float subAmount)
        {
            _energyAmount -= subAmount;

            if (EnergyAmount < 0f)
            {
                Mut.Value = BatteryType.None;
                _energyAmount = 0;
            }
        }

        private float _energyAmount;
        public float EnergyAmount => _energyAmount;
        private ReactiveProperty<BatteryType> Mut { get; }
        private GimmickId GimmickId { get; }
        private BatteryInfo BatteryInfo { get; }
        public Observable<GimmickEventInfo> GimmickEvent =>
            Reader.Select(x => new GimmickEventInfo(x.Conversion(), GimmickId.ID));

        public ReadOnlyReactiveProperty<BatteryType> Reader => Mut;
    }
}