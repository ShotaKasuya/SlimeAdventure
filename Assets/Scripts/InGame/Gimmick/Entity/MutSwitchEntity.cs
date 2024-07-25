using System.Threading;
using InGame.Gimmick.Serializable;
using R3;
using VContainer;

namespace InGame.Gimmick.Entity
{
    public class MutSwitchEntity : ISwitchStateReader, IResettable
    {
        [Inject]
        public MutSwitchEntity(GimmickId gimmickId, CompositeDisposable disposable)
        {
            GimmickId = gimmickId;
            disposable.Add(MutSwitchState);
        }

        public void SetValue(SwitchType type)
        {
            if (SemaphoreSlim.CurrentCount == 0)
            {
                return;
            }

            MutSwitchState.Value = type;
        }

        private GimmickId GimmickId { get; }
        public ReadOnlyReactiveProperty<SwitchType> SwitchReader => MutSwitchState;
        private ReactiveProperty<SwitchType> MutSwitchState { get; } = new ReactiveProperty<SwitchType>(SwitchType.Off);

        public Observable<GimmickEventInfo> GimmickEvent =>
            SwitchReader.Select(x => new GimmickEventInfo(x.Conversion(), GimmickId.ID));

        public SemaphoreSlim SemaphoreSlim { get; } = new SemaphoreSlim(1, 1);

        public void Reset()
        {
            MutSwitchState.Value = SwitchType.Off;
        }
    }
}