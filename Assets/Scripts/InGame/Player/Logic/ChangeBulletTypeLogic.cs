using System;
using InGame.Player.Entity;
using StaticVariables;
using UnityEngine.InputSystem;
using VContainer;

namespace InGame.Player.Logic
{
    public class ChangeBulletTypeLogic
    {
        [Inject]
        public ChangeBulletTypeLogic(MutBulletEntity bulletEntity, PlayerInput playerInput)
        {
            BulletEntity = bulletEntity;
            ChangeAction = playerInput.actions[InputDefinition.BulletChangeAction];
            ChangeAction.performed += _ => ChangeBullet();
        }

        private void ChangeBullet()
        {
            var currentInput = ReadValue();

            if (currentInput == ChangeBulletInputType.None) return;

            switch (currentInput)
            {
                case ChangeBulletInputType.Left:
                    BulletEntity.DecrementType();
                    return;
                case ChangeBulletInputType.Right:
                    BulletEntity.IncrementType();
                    return;
                default:
                    throw new NotImplementedException($"type: {currentInput}");
            }
        }


        private ChangeBulletInputType ReadValue()
        {
            var input = ChangeAction.ReadValue<float>();
            if (input == 0)
            {
                return ChangeBulletInputType.None;
            }

            if (input < 0)
            {
                return ChangeBulletInputType.Left;
            }

            return ChangeBulletInputType.Right;
        }

        private InputAction ChangeAction { get; }
        private MutBulletEntity BulletEntity { get; }
    }
}