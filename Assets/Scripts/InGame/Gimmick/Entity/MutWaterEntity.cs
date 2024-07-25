using InGame.Gimmick.Serializable;
using R3;

namespace InGame.Gimmick.Entity
{
    public class MutWaterEntity : IWaterReader
    {
        public MutWaterEntity(GimmickId gimmickId, CompositeDisposable disposable)
        {
            GimmickId = gimmickId;
            Mut = new ReactiveProperty<WaterType>(WaterType.Water);
            disposable.Add(Mut);
        }

        private GimmickId GimmickId { get; }
        public ReadOnlyReactiveProperty<WaterType> Reader => Mut;
        public ReactiveProperty<WaterType> Mut { get; }

        public Observable<GimmickEventInfo> GimmickEvent =>
            Reader.Select(GimmickId, (type, id) => new GimmickEventInfo(type.Conversion(), id.ID));
    }
}