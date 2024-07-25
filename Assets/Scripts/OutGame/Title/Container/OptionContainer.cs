using OutGame.Title.Logic;
using OutGame.Title.View;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace OutGame.Title.Container
{
    public class OptionContainer : LifetimeScope
    {
        [SerializeField] private OptionView optionView;

        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterInstance(optionView);

            builder.Register<OptionChangeLogic>(Lifetime.Singleton);
        }

        private void Start()
        {
            // FIXME: 
            Container.Resolve<OptionChangeLogic>();
        }
    }
}