using Cysharp.Threading.Tasks;
using InGame.Gimmick.Entity;
using InGame.Gimmick.Provider;
using InGame.Gimmick.Serializable;
using R3;
using VContainer;

namespace InGame.Gimmick.Logic
{
    public class GimmickResetLogic
    {
        [Inject]
        public GimmickResetLogic(GimmickEventProvider eventProvider, ChildGimmickContainers gimmickContainers,
            EventHistoryEntity eventHistoryEntity,
            IEventMaskable eventMaskable, CompositeDisposable disposable)
        {
            eventProvider.EventObservable.Select(eventMaskable.Mask).SubscribeAwait(async (type, token) =>
            {
                if (type == MaskedEventType.OutOfCondition)
                {
                    eventHistoryEntity.EventHistory.Clear();
                    await UniTask.WaitForSeconds(1);

                    gimmickContainers.Reset();
                }
            }).AddTo(disposable);
        }
    }
}