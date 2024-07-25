using InGame.Gimmick.Serializable;
using R3;
using UnityEngine;
using VContainer;

namespace InGame.Gimmick.Entity
{
    public class MutFireEntity : IFireReader, IResettable
    {
        [Inject]
        public MutFireEntity(GimmickId gimmickId, CompositeDisposable disposable)
        {
            GimmickId = gimmickId;
            disposable.Add(Mut);
        }

        public ReadOnlyReactiveProperty<FireType> Reader => Mut;
        private GimmickId GimmickId { get; }
        public ReactiveProperty<FireType> Mut { get; } = new ReactiveProperty<FireType>(FireType.None);

        public Observable<GimmickEventInfo> GimmickEvent =>
            Reader.Select(GimmickId, (x, id) => new GimmickEventInfo(x.Conversion(), id.ID));

        public void Reset()
        {
            Mut.Value = FireType.None;
        }
    }
}