using InGame.Gimmick.Container.Bases;
using InGame.Player.Container;
using InGame.SceneRoot.Entity;
using InGame.SceneRoot.Logic;
using InGame.SceneRoot.Provider;
using R3;
using SaveData;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace InGame.SceneRoot.Container
{
    public class InGameContainer : LifetimeScope
    {
        [SerializeField] private PlayerContainerBase playerContainer;

        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterInstance(new CompositeDisposable());
            builder.RegisterInstance(playerContainer).AsImplementedInterfaces().AsSelf();
            builder.RegisterInstance(FindObjectsByType<ParentGimmickContainerBase>(FindObjectsSortMode.None))
                .AsImplementedInterfaces();

            builder.Register<MutGameStateEntity>(Lifetime.Singleton);

            builder.Register<MessageEventProvider>(Lifetime.Singleton).AsImplementedInterfaces().AsSelf();
            builder.Register<CameraEventProvider>(Lifetime.Singleton).AsImplementedInterfaces().AsSelf();
            builder.Register<StopEventProvider>(Lifetime.Singleton).AsImplementedInterfaces().AsSelf();
            builder.Register<AppendEventProviderLogic>(Lifetime.Singleton);


            builder.Register<CameraEventLogic>(Lifetime.Singleton);
            builder.Register<StopEventLogic>(Lifetime.Singleton);
            builder.Register<SaveLogic>(Lifetime.Singleton);
            builder.Register<LoadLogic>(Lifetime.Singleton);
        }

        private void Start()
        {
            Container.Resolve<AppendEventProviderLogic>();
            Container.Resolve<CameraEventLogic>();
            Container.Resolve<StopEventLogic>();
            var saveData =
                SaveDataManager.Instance.Load();
            Container.Resolve<LoadLogic>().Load(saveData);
        }
    }
}