using InGame.Gimmick.Entity;
using InGame.Gimmick.View;
using R3;
using VContainer;

namespace InGame.Gimmick.Logic
{
    public class WaterToIceLogic
    {
        [Inject]
        public WaterToIceLogic(MutWaterEntity waterEntity, BulletHittableView bulletHittableView)
        {
            bulletHittableView.HitObservable.Subscribe(waterEntity, (interactInfo, entity) =>
            {
                switch (interactInfo.BulletType)
                {
                    case BulletType.Ice:
                        entity.Mut.Value = WaterType.Ice;
                        return;
                    case BulletType.Fire:
                        entity.Mut.Value = WaterType.Water;
                        return;
                }
            }).AddTo(bulletHittableView);
        }
    }
}