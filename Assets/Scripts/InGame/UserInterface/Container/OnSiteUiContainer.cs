using InGame.ScriptableObjects;
using InGame.UserInterface.Logic;
using InGame.UserInterface.View;
using R3;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace InGame.UserInterface.Container
{
    /// <summary>
    /// 常駐UI
    /// </summary>
    public class OnSiteUiContainer : LifetimeScope
    {
        [SerializeField] private PlayerHpUiView hpUiView;
        [SerializeField] private PlayerSpUiView spUiView;
        [SerializeField] private BulletTypeUiView bulletTypeUiView;
        [SerializeField] private BulletAmountUiView bulletAmountUiView;
        [SerializeField] private ItemUiView itemUiView;
        [SerializeField] private PlayerUiConstant uiConstant;
        [SerializeField] private ItemDb itemDb;

        protected override void Configure(IContainerBuilder builder)
        {
            var disposable = new CompositeDisposable();
            disposable.AddTo(this);
            builder.RegisterInstance(disposable);
            // builder.RegisterInstance(hpUiView);
            // builder.RegisterInstance(spUiView);
            builder.RegisterInstance(bulletTypeUiView);
            // builder.RegisterInstance(bulletAmountUiView);
            builder.RegisterInstance(itemUiView);
            builder.RegisterInstance(itemDb);

            builder.RegisterInstance(uiConstant.BulletConstant);
            builder.RegisterInstance(uiConstant.HpGageUiConstant);

            builder.Register<BulletChangeUiLogic>(Lifetime.Singleton);
            builder.Register<ShowItemLogic>(Lifetime.Singleton);
        }

        private void Start()
        {
            Container.Resolve<BulletChangeUiLogic>();
            Container.Resolve<ShowItemLogic>();
        }
    }
}