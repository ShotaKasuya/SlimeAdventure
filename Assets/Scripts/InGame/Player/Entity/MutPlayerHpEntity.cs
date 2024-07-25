using System;
using InGame.ScriptableObjects;
using R3;
using VContainer;

namespace InGame.Player.Entity
{
    public class MutPlayerHpEntity : IHpReader, IDisposable
    {
        [Inject]
        public MutPlayerHpEntity(HpConstant hpConstant)
        {
            Hp = new ReactiveProperty<int>(hpConstant.Normal);
            MaxHp = hpConstant.Normal;
        }

        public ReactiveProperty<int> Hp { get; }
        public int MaxHp { get; }
        public ReadOnlyReactiveProperty<int> HpReader => Hp;
        public ReadOnlyReactiveProperty<bool> IsDead => Hp.Select(x => x > 0).ToReadOnlyReactiveProperty();

        public void Dispose()
        {
            Hp?.Dispose();
        }
    }
}