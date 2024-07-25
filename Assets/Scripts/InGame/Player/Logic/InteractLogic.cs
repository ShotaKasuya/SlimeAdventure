using System.Linq;
using InGame.Interface;
using InGame.Item;
using InGame.Player.Entity;
using InGame.SceneRoot;
using StaticVariables;
using UnityEngine.InputSystem;
using VContainer;

namespace InGame.Player.Logic
{
    public class InteractLogic
    {
        [Inject]
        public InteractLogic(IInteractableReader interactableReader,
            IMessageEventReceiver messageEventReceiver,
            MutItemEntity itemEntity,
            PlayerInput playerInput)
        {
            InteractableReader = interactableReader;
            MessageEventReceiver = messageEventReceiver;
            ItemEntity = itemEntity;
            InteractAction = playerInput.actions[InputDefinition.Interact];
            InteractAction.performed += _ => Interact();
        }

        private void Interact()
        {
            var interactable = InteractableReader.InteractableReader.CurrentValue;
            if (interactable is null) return;
            if (! interactable.NowInteractable) return;

            if (interactable.RequestItem != ItemId.None)
            {
                if (ItemEntity.ItemReader.Any(x => x.Id == interactable.RequestItem))
                {
                    ItemEntity.SubItem(interactable.RequestItem);
                }
                else
                {
                    MessageEventReceiver.Publish(new MessageEvent($"{interactable.RequestItem.ToString()}がありません"));
                    
                    return;
                }
            }

            InteractableReader.InteractableReader.CurrentValue.OnInteract(
                new InteractInfo(InteractableReader.InteractableReader.CurrentValue.Type));
        }

        private IInteractableReader InteractableReader { get; }
        private IMessageEventReceiver MessageEventReceiver { get; }
        private MutItemEntity ItemEntity { get; }
        private InputAction InteractAction { get; }
    }
}