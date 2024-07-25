using R3;

namespace InGame.SceneRoot.Entity
{
    public class MutGameStateEntity : IGameStateReader
    {
        public ReactiveProperty<GameStateType> Mut = new ReactiveProperty<GameStateType>(GameStateType.Play);
        public ReadOnlyReactiveProperty<GameStateType> Reader => Mut;
    }
}