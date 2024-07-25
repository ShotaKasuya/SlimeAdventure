using System.Collections.Generic;
using InGame.Item;
using InGame.Player.Entity;
using InGame.Player.View;
using InGame.ScriptableObjects;
using ObservableCollections;
using SaveData.DataDefinition;
using UnityEngine;
using VContainer;

namespace InGame.Player.Logic
{
    public class PlayerLoadLogic : IPlayerLoadable
    {
        [Inject]
        public PlayerLoadLogic(PlayerView playerView, MutPlayerHpEntity hpEntity,
            MutItemEntity itemEntity, MutBulletEntity bulletEntity, PlayerDebugSymbol debugSymbol)
        {
            PlayerView = playerView;
            PlayerHpEntity = hpEntity;
            ItemEntity = itemEntity;
            BulletEntity = bulletEntity;
            DebugSymbol = debugSymbol;
        }

        public void Load(PlayerData playerData)
        {
            if (!DebugSymbol.DoLoad)
            {
                return;
            }

            ReceiveHp(playerData.Hp);
            ReceiveItems(playerData.HoldItemIds);
            ReceiveBullet(playerData.BulletType);
            ReceivePosition(playerData.Position);
        }


        private void ReceivePosition(Vector3 pos)
        {
            PlayerView.ModelTransform.position = pos;
        }

        private void ReceiveHp(int hp)
        {
            PlayerHpEntity.Hp.Value = hp;
        }

        private void ReceiveItems(List<PlayerItem> items)
        {
            // FIXME
            ItemEntity.ItemList = items;
        }

        private void ReceiveBullet(BulletType bulletType)
        {
            BulletEntity.MutType.Value = bulletType;
        }

        private PlayerView PlayerView { get; }
        private MutPlayerHpEntity PlayerHpEntity { get; }
        private MutItemEntity ItemEntity { get; }
        private MutBulletEntity BulletEntity { get; }
        private PlayerDebugSymbol DebugSymbol { get; }
    }
}