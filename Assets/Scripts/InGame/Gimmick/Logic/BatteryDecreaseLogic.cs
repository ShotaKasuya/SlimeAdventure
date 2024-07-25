using System;
using InGame.Gimmick.Entity;
using InGame.ScriptableObjects;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace InGame.Gimmick.Logic
{
    public class BatteryDecreaseLogic : ITickable
    {
        [Inject]
        public BatteryDecreaseLogic(MutBatteryEntity batteryEntity, BatteryInfo batteryInfo)
        {
            BatteryEntity = batteryEntity;
            BatteryInfo = batteryInfo;
        }

        public void Tick()
        {
            switch (BatteryEntity.Reader.CurrentValue)
            {
                case BatteryType.None:
                    return;
                case BatteryType.SomeEnergy:
                    BatteryEntity.SubEnergy(BatteryInfo.BatteryDecreaseSpeed * Time.deltaTime);
                    return;
                default:
                    throw new NotImplementedException();
            }
        }


        private MutBatteryEntity BatteryEntity { get; }
        private BatteryInfo BatteryInfo { get; }
    }
}