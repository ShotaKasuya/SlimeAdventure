using InGame.Interface;
using R3;

namespace InGame.Player.Entity
{
    public class MutInteractableEntity : IInteractableReader
    {
        public ReactiveProperty<IInteractable> Interactable { get; } = new ReactiveProperty<IInteractable>();
        public ReadOnlyReactiveProperty<IInteractable> InteractableReader => Interactable;
    }
}