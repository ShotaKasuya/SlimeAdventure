using System;
using InGame.Player.Entity;
using InGame.ScriptableObjects;
using StaticVariables;
using UnityEngine;
using UnityEngine.InputSystem;
using VContainer;
using VContainer.Unity;

namespace InGame.Player.Logic
{
    public class PlayerJumpLogic : IDisposable
    {
        [Inject]
        public PlayerJumpLogic(JumpConstant jumpConstant,
            PlayerInput playerInput, MutGroundEntity ground,
            PlayerVelocityEntity velocityEntity,
            MutPlayerStateEntity playerState)
        {
            JumpConstant = jumpConstant;
            JumpAction = playerInput.actions[InputDefinition.JumpAction];
            Ground = ground;
            PlayerStateEntity = playerState;
            VelocityEntity = velocityEntity;
            JumpAction.performed += context => Tick();
        }

        public void Tick()
        {
            if (!Ground.IsGround.CurrentValue) return;

            VelocityEntity.JumpVelocity = JumpConstant.JumpPower;
            PlayerStateEntity.MutState.Value = PlayerStateType.Jump;
            Ground.MutIsGround.Value = false;
        }

        private InputAction JumpAction { get; }
        private JumpConstant JumpConstant { get; }
        private MutGroundEntity Ground { get; }
        private MutPlayerStateEntity PlayerStateEntity { get; }
        private PlayerVelocityEntity VelocityEntity { get; }

        public void Dispose()
        {
            JumpAction?.Dispose();
        }
    }
}