using System.Collections.Generic;
using InGame.Interface;
using InGame.Item;
using InGame.SceneRoot;
using InGame.ScriptableObjects;
using R3;
using SaveData.DataDefinition;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace InGame.Player.Container
{
    public abstract class PlayerContainerBase : LifetimeScope, ILoadable, IPlayerSavable, IBulletTypeReader,
        IInteractableReader, IItemReader, IMessageEventProvider, IPlayerStoppable
    {
        [SerializeField] private PlayerDebugSymbol debugSymbol;

        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterInstance(debugSymbol);
        }

        public void Load(RootSaveData saveData)
        {
            Container.Resolve<IPlayerLoadable>().Load(saveData.PlayerData);
        }

        public PlayerData Save()
        {
            return Container.Resolve<IPlayerSavable>().Save();
        }

        public ReadOnlyReactiveProperty<int> ItemCursorReader => Container.Resolve<IItemReader>().ItemCursorReader;

        IReadOnlyList<PlayerItem> IItemReader.ItemReader => Container.Resolve<IItemReader>().ItemReader;
        public Observable<ItemChangeEvent> ItemObservable => Container.Resolve<IItemReader>().ItemObservable;


        public ReadOnlyReactiveProperty<BulletType> Reader => Container.Resolve<IBulletTypeReader>().Reader;

        public Observable<MessageEvent> MessageEventObservable =>
            Container.Resolve<IMessageEventProvider>().MessageEventObservable;

        public ReadOnlyReactiveProperty<IInteractable> InteractableReader =>
            Container.Resolve<IInteractableReader>().InteractableReader;

        public void Stop()
        {
            Container.Resolve<IPlayerStoppable>().Stop();
        }

        public void Restart()
        {
            Container.Resolve<IPlayerStoppable>().Restart();
        }
    }
}