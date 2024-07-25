using InGame.Player.Entity;
using InGame.Player.View;
using VContainer;
using VContainer.Unity;

namespace InGame.Player.Logic
{
    public class ApplyVelocityLogic : IPostFixedTickable
    {
        [Inject]
        public ApplyVelocityLogic(PlayerView playerView, PlayerVelocityEntity velocityEntity,
            IGroundReader groundReader)
        {
            PlayerView = playerView;
            VelocityEntity = velocityEntity;
            GroundReader = groundReader;
        }

        public void PostFixedTick()
        {
            var velocity = VelocityEntity.CurrentSpeed * VelocityEntity.MoveDirection;
            if (GroundReader.IsGround.CurrentValue)
            {
                PlayerView.ModelRigidbody.velocity = velocity;
                return;
            }

            velocity.y = VelocityEntity.JumpVelocity;
            PlayerView.ModelRigidbody.velocity = velocity;
        }

        private PlayerView PlayerView { get; }
        private PlayerVelocityEntity VelocityEntity { get; }
        private IGroundReader GroundReader { get; }
    }
}