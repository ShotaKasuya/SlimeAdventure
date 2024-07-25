using System;
using System.Linq;
using InGame.ScriptableObjects;
using R3;
using StaticVariables;
using VContainer;

namespace InGame.Player.Entity
{
    public class MutBulletEntity : IBulletTypeReader
    {
        [Inject]
        public MutBulletEntity(Bullets bullets, PlayerDebugSymbol debugSymbol)
        {
            DebugSymbol = debugSymbol;
            MutType = new ReactiveProperty<BulletType>(bullets.StartType);
        }

        public void DecrementType()
        {
            var type = Reader.CurrentValue;
            while (true)
            {
                if (type > 0)
                {
                    type--;
                }
                else
                {
                    type = (BulletType)Enum.GetValues(typeof(BulletType)).Cast<int>().Max();
                }

                if (CheckBulletUsable(type))
                {
                    break;
                }
            }

            MutType.Value = type;
        }

        public void IncrementType()
        {
            var type = Reader.CurrentValue;
            while (true)
            {
                if (type != (BulletType)Enum.GetValues(typeof(BulletType)).Cast<int>().Max())
                {
                    type++;
                }
                else
                {
                    type = 0;
                }

                if (CheckBulletUsable(type))
                {
                    break;
                }
            }

            MutType.Value = type;
        }

        private bool CheckBulletUsable(BulletType type)
        {
            if (DebugSymbol.EnableAllBullet)
            {
                return true;
            }

            return type switch
            {
                BulletType.Fire => PlayerUsableBullets.FireBullet,
                BulletType.Ice => PlayerUsableBullets.IceBullet,
                BulletType.Bolt => PlayerUsableBullets.BoltBullet,
                _ => throw new NotSupportedException()
            };
        }

        private PlayerDebugSymbol DebugSymbol { get; }
        private ChangeBulletInputType _beforeInputType;
        public ReadOnlyReactiveProperty<BulletType> Reader => MutType;
        public ReactiveProperty<BulletType> MutType { get; }
    }
}