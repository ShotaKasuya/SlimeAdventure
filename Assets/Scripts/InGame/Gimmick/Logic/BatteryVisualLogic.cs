using System;
using InGame.Gimmick.Serializable;
using R3;
using VContainer;

namespace InGame.Gimmick.Logic
{
    public class BatteryVisualLogic
    {
        [Inject]
        public BatteryVisualLogic(IBatteryReader batteryReader,
            ChangeableMaterialObject changeableMaterialObject,
            CompositeDisposable disposable)
        {
            batteryReader.Reader.Subscribe(changeableMaterialObject, (info, material) =>
            {
                switch (info)
                {
                    case BatteryType.SomeEnergy:
                        material.Change();
                        break;
                    case BatteryType.None:
                        material.Reset();
                        break;
                    default:
                        throw new NotSupportedException();
                }
            }).AddTo(disposable);
        }
    }
}