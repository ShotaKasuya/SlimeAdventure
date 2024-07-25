using InGame.Player.Entity;
using InGame.ScriptableObjects;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace InGame.Player.Logic
{
    public class GravityLogic:IFixedTickable
    {
        [Inject]
        public GravityLogic(PlayerVelocityEntity velocityEntity, IGroundReader groundReader,
            JumpConstant jumpConstant)
        {
            VelocityEntity = velocityEntity;
            GroundReader = groundReader;
            JumpConstant = jumpConstant;
        }
        
        public void FixedTick()
        {
            var jumpVelocity = VelocityEntity.JumpVelocity;
            if (GroundReader.IsGround.CurrentValue) return;

            jumpVelocity -= JumpConstant.GravityScale * Time.fixedDeltaTime;
            jumpVelocity = Mathf.Clamp(jumpVelocity, -JumpConstant.FallSpeedMax, JumpConstant.JumpPower);

            VelocityEntity.JumpVelocity = jumpVelocity;
        }
        
        private PlayerVelocityEntity VelocityEntity { get; }
        private IGroundReader GroundReader { get; }
        private JumpConstant JumpConstant { get; }
    }
}