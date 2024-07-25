using InGame.Gimmick.Serializable;
using R3;
using UnityEngine;
using VContainer;

namespace InGame.Gimmick.Entity
{
    public class MutIceAmountEntity : IIceAmountReader
    {
        [Inject]
        public MutIceAmountEntity(MeltIceConstant meltIceConstant)
        {
            Amount = new ReactiveProperty<float>(meltIceConstant.InitValuePercentage);
        }

        public void Melt(float amount)
        {
            Amount.Value = Mathf.Clamp(Amount.CurrentValue - amount, 0f, 100f);
        }

        public void Freeze(float amount)
        {
            Amount.Value = Mathf.Clamp(Amount.CurrentValue + amount, 0f, 100f);
        }

        public ReadOnlyReactiveProperty<float> AmountReader => Amount;
        private ReactiveProperty<float> Amount { get; }
    }
}