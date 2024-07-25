using R3;

namespace InGame.Player.Entity
{
    public class AttackStateEntity
    {
        public AttackStateEntity()
        {
            AttackState = new ReactiveProperty<AttackStateType>(AttackStateType.None);
        }

        // FIXME? Request Call this After Tick
        public void AfterTick(bool input)
        {
            _beforeFrameInput = input;
        }

        public bool IsOnInput(bool current)
        {
            return current & !_beforeFrameInput;
        }

        private bool _beforeFrameInput;
        public ReadOnlyReactiveProperty<AttackStateType> Reader => AttackState;
        private ReactiveProperty<AttackStateType> AttackState { get; }
    }
}