using UnityEngine;

namespace InGame.Player.Entity
{
    /// <summary>
    /// 移動速度を持つ
    /// </summary>
    public class PlayerVelocityEntity
    {
        /// <summary>
        /// 移動速度の値
        /// </summary>
        public float CurrentSpeed { get; private set; }
        /// <summary>
        /// 移動方向
        /// </summary>
        public Vector3 MoveDirection;
        public float JumpVelocity { get; set; }

        public void Acceleration(float value)
        {
            CurrentSpeed += value;
        }

        public void Deceleration(float value)
        {
            CurrentSpeed -= value;
            if (CurrentSpeed < 0)
            {
                CurrentSpeed = 0;
            }
        }

        public void ClampSpeed(float max)
        {
            CurrentSpeed = Mathf.Clamp(CurrentSpeed, 0f, max);
        }
    }
}