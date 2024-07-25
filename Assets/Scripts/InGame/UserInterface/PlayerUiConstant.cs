using InGame.UserInterface.Serializable;
using UnityEngine;

namespace InGame.UserInterface
{
    [CreateAssetMenu(fileName = nameof(PlayerUiConstant), menuName = "ScriptableObjects/PlayerUiConstants")]
    public class PlayerUiConstant : ScriptableObject
    {
        public BulletUiConstant BulletConstant => bulletConstant;
        public HpGageUiConstant HpGageUiConstant => hpGageUiConstant;
        public InteractIconConstant InteractIconConstant => interactIconConstant;
        public ItemUiConstant ItemUiConstant => itemUiConstant;

        [SerializeField] private BulletUiConstant bulletConstant;
        [SerializeField] private HpGageUiConstant hpGageUiConstant;
        [SerializeField] private InteractIconConstant interactIconConstant;
        [SerializeField] private ItemUiConstant itemUiConstant;
    }
}