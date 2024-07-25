using InGame.Gimmick.Entity;
using InGame.Gimmick.View;
using R3;
using VContainer;
using VContainer.Unity;

namespace InGame.Gimmick.Logic
{
    public class IgnitionLogic : IStartable
    {
        [Inject]
        public IgnitionLogic(BulletHittableView bulletHittableView, MutFireEntity fireEntity)
        {
            BurnPlant = bulletHittableView;
            FireEntity = fireEntity;
        }

        public void Start()
        {
            BurnPlant.HitObservable.Subscribe(FireEntity, (info, fireEntity) =>
            {
                switch (info.BulletType)
                {
                    case BulletType.Fire:
                        fireEntity.Mut.Value = FireType.Burning;
                        break;
                    case BulletType.Ice:
                        fireEntity.Mut.Value = FireType.None;
                        break;
                }
            }).AddTo(BurnPlant);
        }

        private BulletHittableView BurnPlant { get; }
        private MutFireEntity FireEntity { get; }
    }
}