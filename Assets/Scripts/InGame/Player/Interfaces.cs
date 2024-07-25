using System.Collections.Generic;
using InGame.Interface;
using InGame.Item;
using ObservableCollections;
using R3;
using SaveData.DataDefinition;
using UnityEngine;

namespace InGame.Player
{
    public interface IPlayerAnimationCallback
    {
        public void OnCallChangeFace(string str);
        public void OnFootStomp();
    }
    public delegate void OnFootStomp();

    public interface IGroundReader
    {
        public int RaycastHitNum { get; }
        public RaycastHit RaycastHit { get; }
        public ReadOnlyReactiveProperty<bool> IsGround { get; }
    }

    public interface IHpReader
    {
        public int MaxHp { get; }
        public ReadOnlyReactiveProperty<int> HpReader { get; }
        public ReadOnlyReactiveProperty<bool> IsDead { get; }
    }

    public interface IItemReader
    {
        public ReadOnlyReactiveProperty<int> ItemCursorReader { get; }

        public IReadOnlyList<PlayerItem> ItemReader { get; }

        // FIXME: 通知にしか使ってない
        public Observable<ItemChangeEvent> ItemObservable { get; }
    }

    public interface IInteractableReader
    {
        public ReadOnlyReactiveProperty<IInteractable> InteractableReader { get; }
    }

    public interface IPlayerStateReader
    {
        public ReadOnlyReactiveProperty<PlayerStateType> StateReader { get; }
    }

    public interface IBulletTypeReader
    {
        public ReadOnlyReactiveProperty<BulletType> Reader { get; }
    }

    public interface IPlayerSavable
    {
        public PlayerData Save();
    }

    public interface IPlayerLoadable
    {
        public void Load(PlayerData playerData);
    }

    public interface IPlayerStoppable
    {
        public void Stop();
        public void Restart();
    }

    public interface ISavablePosition
    {
        public void ReceivePosition(Vector3 pos);
        public Vector3 SendPosition();
    }

    public interface ISavableHp
    {
        public void ReceiveHp(int hp);
        public int SendHp();
    }

    public interface ISavableItems
    {
        public void ReceiveItems(List<ItemId> itemIds);
        public List<ItemId> SendItems();
    }
}