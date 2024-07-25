using System;
using InGame.Player.Container;
using KanKikuchi.AudioManager;
using SceneTransition;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace InGame.ScriptableObjects
{
    // Define immutable values

    [Serializable]
    public class MoveSpeedConstant
    {
        public float NormalAcceleration => normalAcceleration;
        public float NormalSpeedMax => normalSpeedMax;
        public float RunAcceleration => runAcceleration;
        public float RunSpeedMax => runSpeedMax;
        public float DecelerationMax => decelerationMax;
        public float DecelerationRatio => decelerationRatio;

        [SerializeField] private float normalAcceleration = 5f;
        [SerializeField] private float runAcceleration = 10f;
        [SerializeField] private float normalSpeedMax = 10f;
        [SerializeField] private float runSpeedMax = 20f;
        [SerializeField] private float decelerationMax = 5f;
        [SerializeField] [Range(0, 1)] private float decelerationRatio = 0.5f;
    }

    [Serializable]
    public class JumpConstant
    {
        public float JumpPower => jumpPower;
        public float GravityScale => gravityScale;
        public float FallSpeedMax => fallSpeedMax;
        public string JumpSe => jumpSe;

        [SerializeField] private float jumpPower = 100f;
        [SerializeField] private float gravityScale = 9.8f;
        [SerializeField] private float fallSpeedMax = 10f;
        [SerializeField] [DropdownConstants(typeof(SEPath))]
        private string jumpSe;
    }

    [Serializable]
    public class CameraConstant
    {
        public float SenseBase => senseBase;
        public float CameraRotationXMax => cameraRotationXMax;
        public float CameraRotationXMin => cameraRotationXMin;
        public float CameraDistance => cameraDistance;

        [SerializeField] private float senseBase = 50f;
        [SerializeField] private float cameraRotationXMax = 60f;
        [SerializeField] private float cameraRotationXMin = -60f;
        [SerializeField] private float cameraDistance = 10f;
    }

    [Serializable]
    public class HpConstant
    {
        public int Normal => normal;

        [SerializeField] private int normal = 5;
    }

    [Serializable]
    public class Bullets
    {
        public BulletContainer GetBullet(BulletType type)
        {
            switch (type)
            {
                case BulletType.Fire:
                    return fireBullet;
                case BulletType.Ice:
                    return iceBullet;
                case BulletType.Bolt:
                    return boltBullet;
                default:
                    throw new Exception("Not Set Bullet");
            }
        }

        public string GetSe(BulletType type)
        {
            return type switch
            {
                BulletType.Fire => fireSe,
                BulletType.Ice => iceSe,
                BulletType.Bolt => boltSe,
                _ => throw new NotSupportedException()
            };
        }

        public BulletType StartType => startType;
        public float ShootPower => shootPower;

        [SerializeField] private float shootPower = 5f;
        [SerializeField] private BulletType startType;
        [SerializeField] private BulletContainer fireBullet;
        [SerializeField] private BulletContainer iceBullet;
        [SerializeField] private BulletContainer boltBullet;
        [SerializeField] [DropdownConstants(typeof(SEPath))]
        private string fireSe;
        [SerializeField] [DropdownConstants(typeof(SEPath))]
        private string iceSe;
        [SerializeField] [DropdownConstants(typeof(SEPath))]
        private string boltSe;
    }

    [Serializable]
    public class GroundRaycastInfo
    {
        public int RaycastHitBufferSize => raycastHitBufferSize;
        public float RaycastDistance => raycastDistance;
        public float MaxGroundAngle => maxGroundAngle;
        public LayerMask GroundLayerMask => groundLayerMask;

        [SerializeField] private int raycastHitBufferSize = 5;
        [SerializeField] private float raycastDistance = 0.5f;
        [SerializeField] private float maxGroundAngle = 60f;
        [SerializeField] private LayerMask groundLayerMask;
    }

    [Serializable]
    public class ShootInfo
    {
        public float Interval => interval;
        public float ChargeTime => chargeTime;
        public string ShotSe => shotSe;

        [SerializeField] private float interval;
        [SerializeField] private float chargeTime;

        [SerializeField] [DropdownConstants(typeof(SEPath))]
        private string shotSe;
    }

    [Serializable]
    public class PlayerLookConstant
    {
        public float NotRotationSpeedMax => notRotationSpeedMax;
        public float SmoothTime => smoothTime;

        [SerializeField] private float notRotationSpeedMax = 0.2f;
        [SerializeField] private float smoothTime = 0.1f;
    }

    [Serializable]
    public class PlayerDebugSymbol
    {
        public bool DoLoad => doLoad;
        public bool DoSave => doSave;
        public bool EraseCursor => eraseCursor;
        public bool EnableAllBullet => enableAllBullet;

        [SerializeField] private bool doLoad;
        [SerializeField] private bool doSave;
        [SerializeField] private bool eraseCursor = true;
        [SerializeField] private bool enableAllBullet;
    }

    [Serializable]
    public class ItemUseConstant
    {
        public float InteractDistanceMax => interactDistanceMax;
        public LayerMask InteractableLayerMask => interactableLayerMask;

        [SerializeField] private float interactDistanceMax;
        [SerializeField] private LayerMask interactableLayerMask;
    }
    

    [Serializable]
    public class SceneAssetPair
    {
#if UNITY_EDITOR
        public SceneAsset SceneAsset => sceneAsset;
        [SerializeField] private SceneAsset sceneAsset;
#endif
        
        public SceneDefinition Scene => scene;

        [SerializeField] private SceneDefinition scene;
    }
    
    [Serializable]
    public class BgmPair
    {
        public string BGM => bgm;
        public SceneDefinition Scene => scene;

        [SerializeField]
        [DropdownConstants(typeof(BGMPath))]
        private string bgm;
        [SerializeField] private SceneDefinition scene;
    }

    [Serializable]
    public class TextureSe
    {
        public string FootStompSe => footStompSe;
        
        [SerializeField] [DropdownConstants(typeof(SEPath))]
        private string footStompSe;
    }
}