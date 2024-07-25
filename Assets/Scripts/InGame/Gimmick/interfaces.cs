using System.Threading;
using DG.Tweening;
using InGame.Gimmick.Serializable;
using InGame.Interface;
using R3;

namespace InGame.Gimmick
{
    ///============================================================================================
    /// Entity Interface
    ///============================================================================================
    public interface IFireReader : IConvertible2ChildGimmickEvent
    {
        ReadOnlyReactiveProperty<FireType> Reader { get; }
    }

    public interface IWaterReader : IConvertible2ChildGimmickEvent
    {
        ReadOnlyReactiveProperty<WaterType> Reader { get; }
    }

    public interface IBatteryReader : IConvertible2ChildGimmickEvent
    {
        float EnergyAmount { get; }
        ReadOnlyReactiveProperty<BatteryType> Reader { get; }
    }

    public interface IIceAmountReader
    {
        ReadOnlyReactiveProperty<float> AmountReader { get; }
    }

    public interface ISwitchStateReader : IConvertible2ChildGimmickEvent
    {
        ReadOnlyReactiveProperty<SwitchType> SwitchReader { get; }
        SemaphoreSlim SemaphoreSlim { get; }
    }

    /// <summary>
    /// ギミックがギミックに渡すイベント
    /// </summary>
    public interface IConvertible2ChildGimmickEvent
    {
        public Observable<GimmickEventInfo> GimmickEvent { get; }
    }

    public interface IResettable
    {
        public void Reset();
    }

    ///============================================================================================
    /// Logic Interface
    ///============================================================================================
    public interface IEventMaskable
    {
        MaskedEventType Mask(GimmickEventInfo eventInfo);
    }

    public interface IInteractReceivable
    {
        void Receive(BulletInfo bulletInfo);
    }

    // ?
    public interface ISequenceAppender
    {
        public void Append(Tween tween);
    }
}