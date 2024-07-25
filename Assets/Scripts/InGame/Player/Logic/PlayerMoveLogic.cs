using InGame.Player.Entity;
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
    public class PlayerMoveLogic : ITickable, IFixedTickable
    {
        [Inject]
        public PlayerMoveLogic(MoveSpeedConstant moveSpeedConstant, PlayerView playerView,
            ChildComponentView childComponentView, PlayerInput inputAction, IGroundReader groundReaderEntity,
            PlayerVelocityEntity velocityEntity, IPlayerStateReader playerStateReader,
            GroundRaycastInfo groundRaycastInfo, CompositeDisposable disposable)
        {
            MoveSpeedConstant = moveSpeedConstant;
            ChildComponentView = childComponentView;
            PlayerView = playerView;
            GroundReader = groundReaderEntity;
            MoveAction = inputAction.actions[InputDefinition.MoveAction];
            DashAction = inputAction.actions[InputDefinition.DashAction];
            VelocityEntity = velocityEntity;
            GroundRaycastInfo = groundRaycastInfo;
            PlayerStateReader = playerStateReader;

            disposable.Add(MoveAction);
            disposable.Add(DashAction);
        }

        public void Tick()
        {
            var velocity = PlayerView.ModelRigidbody.velocity;
            var rotateTarget = new Vector3(velocity.x, 0f, velocity.z);
            if (rotateTarget.sqrMagnitude > 3f && PlayerStateReader.StateReader.CurrentValue != PlayerStateType.Jump)
            {
                var lookRotation = Quaternion.LookRotation(rotateTarget);
                if (Quaternion.Angle(PlayerView.ModelTransform.rotation, lookRotation) > 5.0f)
                {
                    PlayerView.ModelTransform.rotation = Quaternion.Slerp(PlayerView.ModelTransform.rotation,
                        lookRotation, 0.2f);
                }
            }
        }

        public void FixedTick()
        {
            var slopeAngle = CheckSlope();
            Vector3 moveVector3;
            var isMaxGroundAngle = slopeAngle >= GroundRaycastInfo.MaxGroundAngle;
            if (isMaxGroundAngle)
            {
                moveVector3 = Vector3.ProjectOnPlane(Vector3.down, GroundReader.RaycastHit.normal);
                VelocityEntity.MoveDirection = moveVector3;
                return;
            }


            var (moveVector2, isDashing) = ReadValue();

            if (DoDeceleration(moveVector2))
            {
                Deceleration();
                return;
            }

            RefineVector(in moveVector2, out moveVector3);
            var addSpeed = GetAcceleration(isDashing);


            VelocityEntity.MoveDirection = moveVector3;
            VelocityEntity.Acceleration(addSpeed);

            ClampVelocity(isDashing);
        }

        /// <summary>
        /// カメラから見た方向の地面に平行なベクトルに直す
        /// </summary>
        /// <returns>カメラ基準の入力</returns>
        private void RefineVector(in Vector2 input, out Vector3 output)
        {
            RaycastHit near = GroundReader.RaycastHit;
            Vector3 cameraRight = ChildComponentView.CameraTransform.right;
            Vector3 cameraForward = ChildComponentView.CameraTransform.forward;

            Vector3 movementRight = Vector3.ProjectOnPlane(cameraRight, near.normal);
            Vector3 movementForward = Vector3.ProjectOnPlane(cameraForward, near.normal);

            output = movementRight.normalized * input.x + movementForward.normalized * input.y;
        }

        /// <summary>
        /// 速度を制限
        /// </summary>
        /// <param name="isDashing">ダッシュ中か</param>
        private void ClampVelocity(bool isDashing)
        {
            if (isDashing && PlayerStateReader.StateReader.CurrentValue != PlayerStateType.Jump)
            {
                VelocityEntity.ClampSpeed(MoveSpeedConstant.RunSpeedMax);
            }
            else
            {
                VelocityEntity.ClampSpeed(MoveSpeedConstant.NormalSpeedMax);
            }
        }

        /// <summary>
        /// スピードを掛け合わせる
        /// </summary>
        /// <param name="isDash">ダッシュ中か</param>
        private float GetAcceleration(bool isDash)
        {
            if (isDash)
            {
                return MoveSpeedConstant.RunAcceleration * Time.fixedDeltaTime;
            }
            else
            {
                return MoveSpeedConstant.NormalAcceleration * Time.fixedDeltaTime;
            }
        }

        /// <summary>
        /// 減速を行うか判定
        /// </summary>
        /// <param name="moveVector">入力値</param>
        /// <returns>判定結果</returns>
        private bool DoDeceleration(in Vector3 moveVector)
        {
            var moveZero = moveVector == Vector3.zero;

            var result = moveZero;
            return result;
        }

        private void Deceleration()
        {
            var speed = VelocityEntity.CurrentSpeed;
            VelocityEntity.Deceleration(speed * (1 - MoveSpeedConstant.DecelerationRatio));
        }

        private float CheckSlope()
        {
            var groundAngle = 90f - Mathf.Asin(GroundReader.RaycastHit.normal.y) * 180f / Mathf.PI;
            return groundAngle;
        }


        private (Vector2, bool) ReadValue()
        {
            var vec = MoveAction.ReadValue<Vector2>().normalized;
            var isDashing = DashAction.ReadValue<float>() > 0;

            return (vec, isDashing);
        }


        private MoveSpeedConstant MoveSpeedConstant { get; }
        private GroundRaycastInfo GroundRaycastInfo { get; }
        private PlayerView PlayerView { get; }
        private ChildComponentView ChildComponentView { get; }
        private IGroundReader GroundReader { get; }
        private InputAction MoveAction { get; }
        private InputAction DashAction { get; }
        private PlayerVelocityEntity VelocityEntity { get; }
        private IPlayerStateReader PlayerStateReader { get; }
    }
}