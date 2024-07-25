using InGame.Player.Entity;
using StaticVariables;
using UnityEngine.InputSystem;
using VContainer;

namespace InGame.Player.Logic
{
    public class ItemChangeLogic
    {
        [Inject]
        public ItemChangeLogic(MutItemEntity itemEntity, PlayerInput playerInput)
        {
            ItemEntity = itemEntity;
            InputAction = playerInput.actions[InputDefinition.ChangeItemAction];
            InputAction.performed += ctx => ChangeItem();
        }

        private void ChangeItem()
        {
            var input = InputAction.ReadValue<float>();

            if (input > 0)
            {
                ItemEntity.IncCursor();
            }
            else
            {
                ItemEntity.DecCursor();
            }
        }

        private MutItemEntity ItemEntity { get; }
        private InputAction InputAction { get; }
    }
}