using UnityEngine;
using UnityEngine.Serialization;

namespace InGame.ScriptableObjects
{
    [CreateAssetMenu(fileName = "PlayerStatus", menuName = "ScriptableObjects/PlayerStatus")]
    public class PlayerConstants : ScriptableObject
    {
        public MoveSpeedConstant MoveSpeedConstant => moveSpeedConstant;
        public JumpConstant JumpConstant => jumpConstant;
        public CameraConstant CameraConstant => cameraConstant;
        public HpConstant HpConstant => hpConstant;
        public GroundRaycastInfo RaycastInfo => groundRaycastInfo;
        public Bullets Bullets => bullets;
        public ShootInfo ShootInfo => shootInfo;
        public PlayerLookConstant PlayerLookConstant => playerLookConstant;
        public ItemUseConstant ItemUseConstant => itemUseConstant;

        [SerializeField] private MoveSpeedConstant moveSpeedConstant;
        [FormerlySerializedAs("jumpPowerConstant")] [SerializeField] private JumpConstant jumpConstant;
        [SerializeField] private CameraConstant cameraConstant;
        [SerializeField] private HpConstant hpConstant;
        [SerializeField] private GroundRaycastInfo groundRaycastInfo;
        [SerializeField] private Bullets bullets;
        [SerializeField] private ShootInfo shootInfo;
        [SerializeField] private PlayerLookConstant playerLookConstant;
        [SerializeField] private ItemUseConstant itemUseConstant;
    }
}