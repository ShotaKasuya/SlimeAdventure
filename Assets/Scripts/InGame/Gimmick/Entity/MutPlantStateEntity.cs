using InGame.SceneRoot;
using R3;

namespace InGame.Gimmick.Entity
{
    public class MutPlantStateEntity : IConvertible2ParentGimmickEvent
    {
        public ReactiveProperty<PlantStateType> Mut { get; }
        public ReadOnlyReactiveProperty<GameEventType> Reader { get; }
    }
}