using InGame.Gimmick.Provider;
using InGame.Gimmick.View;
using R3;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace InGame.Gimmick.Logic
{
    public class ActivationLogic: IPostStartable
    {
        [Inject]
        public ActivationLogic(GimmickViewBase viewBase, IEventMaskable maskable,
            GimmickEventProvider eventProvider, CompositeDisposable disposable)
        {
            GimmickViewBase = viewBase;
            EventMaskable = maskable;
            GimmickEventProvider = eventProvider;
            Disposable = disposable;
            
        }

        public void PostStart()
        {
            GimmickViewBase.gameObject.SetActive(false);
            GimmickEventProvider.EventObservable.Select(EventMaskable.Mask).Subscribe(GimmickViewBase, (type, view) =>
            {
                switch (type)
                {
                    case MaskedEventType.InCondition:
                        view.gameObject.SetActive(true);
                        return;
                    case MaskedEventType.OutOfCondition:
                        view.gameObject.SetActive(false);
                        return;
                }
            }).AddTo(Disposable);
        }

        private GimmickViewBase GimmickViewBase { get; }
        private IEventMaskable EventMaskable { get; }
        private GimmickEventProvider GimmickEventProvider { get; }
        private CompositeDisposable Disposable { get; }
    }
}