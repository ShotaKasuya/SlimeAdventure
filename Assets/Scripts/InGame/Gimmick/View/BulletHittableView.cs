using System;
using InGame.Interface;
using R3;

namespace InGame.Gimmick.View
{
    public class BulletHittableView : GimmickViewBase, IHitBullet, IDisposable
    {
        private Subject<BulletInfo> HitEvent { get; } = new Subject<BulletInfo>();
        public Observable<BulletInfo> HitObservable => HitEvent;

        public void OnHit(BulletInfo bulletInfo)
        {
            HitEvent.OnNext(bulletInfo);
        }

        public void Dispose()
        {
            HitEvent.Dispose();
        }
    }
}