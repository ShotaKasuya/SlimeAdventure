using System;

namespace InGame.Gimmick
{
    public enum GimmickStateType
    {
        None,

        // Gimmick
        OnFailed,
        OnCompleted,
    }

    public enum GimmickEventType
    {
        OnExtinguish,
        OnBurn,
        OnIceMelt,
        OnWaterFreezes,
        OnCharge,
        OnDeadBattery,
        OnSwitchTurnOn,
        OnSwitchTurnOff,
        OnUsedKey,
    }

    ///==================================================================================
    /// Child Gimmick
    ///==================================================================================
    public enum FireType
    {
        None,
        Burning,
    }

    public enum WaterType
    {
        Water,
        Ice,
    }

    public enum BatteryType
    {
        None,
        SomeEnergy,
    }

    public enum SwitchType
    {
        Off,
        On,
    }

    ///==================================================================================
    /// Parent Gimmick
    ///==================================================================================
    public enum PlantStateType
    {
        IsAlive,
        IsBurning,
        IsDead,
    }

    /// <summary>
    /// イベントのオプション
    /// </summary>
    public enum EventMaskType
    {
        AllLightBurning,
        SeriesCircuit,
        ParallelCircuit,
        OpenKeyUsed,
        BurnedInOrder,
        SwitchOn,
        AllSwitchOn,
    }

    public enum MaskedEventType
    {
        None,
        InCondition,
        OutOfCondition,
    }

    public static class EnumExtensions
    {
        public static GimmickEventType Conversion(this WaterType type)
        {
            return type switch
            {
                WaterType.Water => GimmickEventType.OnIceMelt,
                WaterType.Ice => GimmickEventType.OnWaterFreezes,
                _ => throw new NotImplementedException(),
            };
        }

        public static GimmickEventType Conversion(this FireType type)
        {
            return type switch
            {
                FireType.None => GimmickEventType.OnExtinguish,
                FireType.Burning => GimmickEventType.OnBurn,
                _ => throw new NotImplementedException(),
            };
        }

        public static GimmickEventType Conversion(this BatteryType type)
        {
            return type switch
            {
                BatteryType.None => GimmickEventType.OnDeadBattery,
                BatteryType.SomeEnergy => GimmickEventType.OnCharge,
                _ => throw new NotImplementedException()
            };
        }

        public static GimmickEventType Conversion(this SwitchType type)
        {
            return type switch
            {
                SwitchType.On => GimmickEventType.OnSwitchTurnOn,
                SwitchType.Off => GimmickEventType.OnSwitchTurnOff,
                _ => throw new NotImplementedException()
            };
        }

        public static GimmickStateType Conversion(this PlantStateType type)
        {
            return type switch
            {
                PlantStateType.IsAlive => GimmickStateType.None,
                PlantStateType.IsBurning => GimmickStateType.None,
                PlantStateType.IsDead => GimmickStateType.OnCompleted,
                _ => throw new NotImplementedException()
            };
        }
    }
}