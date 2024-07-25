using InGame.UserInterface.Entity;
using InGame.UserInterface.Logic;
using InGame.UserInterface.Serializable;
using InGame.UserInterface.View;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace InGame.UserInterface.Container
{
    /// <summary>
    /// 非常駐UI
    /// </summary>
    public class PopUpUiContainer : LifetimeScope
    {
        [SerializeField] private InteractIconView interactIconView;
        [SerializeField] private PopTextUiView popTextUiView;
        [SerializeField] private PopUpTextConstant popUpTextConstant;
        [SerializeField] private InteractIconConstant interactIconConstant;

        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterInstance(interactIconView);
            builder.RegisterInstance(popTextUiView);

            builder.RegisterInstance(popUpTextConstant);
            builder.RegisterInstance(interactIconConstant);

            builder.Register<PopUpTextEntity>(Lifetime.Singleton);

            builder.Register<PopUpMessageLogic>(Lifetime.Singleton);
            builder.Register<InteractIconLogic>(Lifetime.Singleton);
        }

        private void Start()
        {
            Container.Resolve<PopUpMessageLogic>();
            Container.Resolve<InteractIconLogic>();
        }
    }
}