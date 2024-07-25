using UnityEngine;
using UnityEngine.InputSystem;
using VContainer;

namespace InGame.Player.Logic
{
    public class PlayerStopLogic : IPlayerStoppable
    {
        [Inject]
        public PlayerStopLogic(PlayerInput playerInput)
        {
            PlayerInput = playerInput;
        }

        public void Stop()
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            PlayerInput.DeactivateInput();
        }

        public void Restart()
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            PlayerInput.ActivateInput();
        }

        private PlayerInput PlayerInput { get; }
    }
}