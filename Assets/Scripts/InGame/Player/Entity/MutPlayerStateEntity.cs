using R3;

namespace InGame.Player.Entity
{
    public class MutPlayerStateEntity : IPlayerStateReader
    {
        public ReadOnlyReactiveProperty<PlayerStateType> StateReader => MutState;

        public ReactiveProperty<PlayerStateType> MutState { get; } =
            new ReactiveProperty<PlayerStateType>(PlayerStateType.Idle);
    }
}