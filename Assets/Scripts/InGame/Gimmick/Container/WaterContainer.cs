using System.Linq;
using InGame.Gimmick.Container.Bases;
using InGame.Gimmick.Entity;
using InGame.Gimmick.Logic;
using InGame.Gimmick.Serializable;
using InGame.Gimmick.View;
using R3;
using UnityEngine;
using VContainer;

namespace InGame.Gimmick.Container
{
    [RequireComponent(typeof(BulletHittableView))]
    public class WaterContainer : ChildGimmickContainerBase
    {
        [SerializeField] private ChangeableMaterialObject materialObject;
        [SerializeField] private ChangeableSizeObject sizeObject;

        protected override void Configure(IContainerBuilder builder)
        {
            base.Configure(builder);
            builder.RegisterInstance(GetComponent<BulletHittableView>()).AsImplementedInterfaces().AsSelf();
            builder.RegisterInstance(GetCollider());
            builder.RegisterInstance(materialObject);
            builder.RegisterInstance(sizeObject);
            builder.RegisterInstance(new CompositeDisposable());

            builder.Register<MutWaterEntity>(Lifetime.Singleton)
                .AsImplementedInterfaces().AsSelf();

            builder.Register<WaterToIceLogic>(Lifetime.Singleton);
            builder.Register<ManageWaterTextureLogic>(Lifetime.Singleton);
            builder.Register<ManageWaterColliderLogic>(Lifetime.Singleton);
        }

        private void Start()
        {
            Container.Resolve<WaterToIceLogic>();
            Container.Resolve<ManageWaterTextureLogic>();
            Container.Resolve<ManageWaterColliderLogic>();
        }

        // 当たり判定があるコライダーをGet
        private BoxCollider GetCollider()
        {
            var colliders = GetComponents<BoxCollider>();
            return colliders.First(x => x.isTrigger == false);
        }
    }
}