using InGame.Gimmick.Entity;
using InGame.Gimmick.Serializable;
using InGame.Gimmick.View;
using R3;
using VContainer;

namespace InGame.Gimmick.Logic
{
    public class IceMeltLogic
    {
        [Inject]
        public IceMeltLogic(MutIceAmountEntity iceAmountEntity, BulletHittableView bulletHittableView,
            MeltIceConstant iceConstant)
        {
            bulletHittableView.HitObservable
                .Subscribe(x =>
                {
                    switch (x.BulletType)
                    {
                        case BulletType.Fire:
                            iceAmountEntity.Melt(iceConstant.Delta);
                            break;
                        case BulletType.Ice:
                            iceAmountEntity.Freeze(iceConstant.Delta);
                            break;
                    }
                }).AddTo(bulletHittableView);
        }
    }
}