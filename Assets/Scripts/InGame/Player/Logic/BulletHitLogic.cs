using InGame.Interface;
using InGame.Player.View;
using InGame.ScriptableObjects;
using R3;
using UnityEngine;
using VContainer;

namespace InGame.Player.Logic
{
    public class BulletHitLogic
    {
        [Inject]
        public BulletHitLogic(BulletConstants bulletConstants, BulletView bulletView)
        {
            bulletView.ObservableTriggerEnter
                .Where(bulletConstants, (collider, info) =>
                {
                    var layer = collider.gameObject.layer;
                    return ((1 << layer) & info.InteractLayer) != 0;
                })
                .Subscribe(bulletView, (collider, view) => 
                {
                    if (collider.TryGetComponent<IHitBullet>(out var hitBullet))
                    {
                        hitBullet.OnHit(new BulletInfo(bulletConstants.BulletType, bulletConstants.BasePower));
                    }
                    Object.Destroy(view);
                }).AddTo(bulletView);
        }
    }
}