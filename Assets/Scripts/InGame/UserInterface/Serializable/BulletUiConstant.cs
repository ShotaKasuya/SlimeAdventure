using System;
using DG.Tweening;
using UnityEngine;

namespace InGame.UserInterface.Serializable
{
    [Serializable]
    public class BulletUiConstant
    {
        public Sprite GetSprite(BulletType bulletType)
        {
            return bulletType switch
            {
                BulletType.Fire => fileSprite,
                BulletType.Ice => iceSprite,
                BulletType.Bolt => boltSprite,
            };
        }

        public float PopUpDuration => popUpDuration;
        public Ease PopUpEase => popUpEase;

        [SerializeField] private float popUpDuration = 0.5f;
        [SerializeField] private Ease popUpEase;
        [SerializeField] private Sprite fileSprite;
        [SerializeField] private Sprite iceSprite;
        [SerializeField] private Sprite boltSprite;
    }
}