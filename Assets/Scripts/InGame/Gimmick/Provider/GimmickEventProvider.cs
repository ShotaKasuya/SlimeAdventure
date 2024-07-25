using System.Collections.Generic;
using System.Linq;
using InGame.Gimmick.Container.Bases;
using InGame.Gimmick.Serializable;
using R3;
using VContainer;
using VContainer.Unity;

namespace InGame.Gimmick.Provider
{
    public class GimmickEventProvider : IStartable
    {
        [Inject]
        public GimmickEventProvider(ChildGimmickContainers childGimmickContainers,
            CompositeDisposable disposable)
        {
            GimmickContainerBases = childGimmickContainers.GimmickContainers;
            Disposable = disposable;
        }

        public void Start()
        {
            _readOnlyReactiveProperties = GimmickContainerBases.Select(x => x.GimmickEvent.ToReadOnlyReactiveProperty())
                .ToArray();
            foreach (var property in _readOnlyReactiveProperties)
            {
                property.Subscribe(EventProvider, (type, subject) => { subject.OnNext(type); }).AddTo(Disposable);
            }

            Disposable.Add(EventProvider);
        }

        public void AppendProvider(Observable<GimmickEventInfo> eventObservable)
        {
            eventObservable.Subscribe(EventProvider, (info, subject) => { subject.OnNext(info); }).AddTo(Disposable);
        }

        private CompositeDisposable Disposable { get; }
        public Observable<GimmickEventInfo> EventObservable => EventProvider;
        private Subject<GimmickEventInfo> EventProvider { get; } = new Subject<GimmickEventInfo>();
        private IReadOnlyList<ReadOnlyReactiveProperty<GimmickEventInfo>> _readOnlyReactiveProperties;
        private IReadOnlyList<ChildGimmickContainerBase> GimmickContainerBases { get; }
        public IEnumerable<GimmickEventInfo> EventInfos => _readOnlyReactiveProperties.Select(x => x.CurrentValue);
    }
}