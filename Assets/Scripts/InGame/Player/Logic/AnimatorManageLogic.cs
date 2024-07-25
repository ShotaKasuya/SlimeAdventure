using InGame.Player.View;
using InGame.ScriptableObjects;
using R3;
using StaticVariables;
using UnityEngine;
using UnityEngine.InputSystem;
using VContainer;
using VContainer.Unity;

namespace InGame.Player.Logic
{
    public class AnimatorManageLogic : ITickable
    {
        [Inject]
        public AnimatorManageLogic(PlayerView playerView, Animator animator,
            IGroundReader groundReader, MoveSpeedConstant moveSpeedConstant,
            PlayerInput playerInput, IPlayerStateReader playerStateReader)
        {
            PlayerView = playerView;
            Animator = animator;
            GroundReader = groundReader;
            MoveSpeedConstant = moveSpeedConstant;
            playerStateReader.StateReader.Subscribe(animator, (x, anim) =>
            {
                switch (x)
                {
                    case PlayerStateType.Jump:
                        anim.SetTrigger(Jump);
                        break;
                }
            }).AddTo(playerView);
        }

        public void Tick()
        {
            SetIsGround();
            SetSpeed();
        }

        private void SetIsGround()
        {
            Animator.SetBool(IsGroundId, GroundReader.IsGround.CurrentValue);
        }

        private void SetSpeed()
        {
            var vel = PlayerView.ModelRigidbody.velocity;
            float currentSpeed = new Vector2(vel.x, vel.z).sqrMagnitude;
            float maxSpeed = MoveSpeedConstant.RunSpeedMax;
            Animator.SetFloat(SpeedId, currentSpeed / maxSpeed);
        }

        private PlayerView PlayerView { get; }
        private IGroundReader GroundReader { get; }
        private MoveSpeedConstant MoveSpeedConstant { get; }
        private Animator Animator { get; }
        private int IsGroundId { get; } = Animator.StringToHash(AnimationDefinition.IsGround);
        private int SpeedId { get; } = Animator.StringToHash(AnimationDefinition.Speed);
        private int Jump { get; } = Animator.StringToHash(AnimationDefinition.Jump);
    }
}