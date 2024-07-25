using System.Collections.Generic;
using InGame.Item;
using InGame.Player.Entity;
using InGame.Player.View;
using InGame.ScriptableObjects;
using SaveData.DataDefinition;
using UnityEngine;
using VContainer;

namespace InGame.Player.Logic
{
    public class PlayerSaveLogic : IPlayerSavable
    {
        [Inject]
        public PlayerSaveLogic(PlayerView playerView, MutPlayerHpEntity playerHpEntity,
            MutItemEntity itemEntity, MutBulletEntity bulletEntity, PlayerDebugSymbol debugSymbol)
        {
            PlayerView = playerView;
            PlayerHpEntity = playerHpEntity;
            ItemEntity = itemEntity;
            BulletEntity = bulletEntity;
            DebugSymbol = debugSymbol;
        }

        public PlayerData Save()
        {
            if (!DebugSymbol.DoSave)
            {
                Debug.Log("VAR");
                return null;
            }

            var pos = SendPosition();
            Debug.Log($"{pos}");
            var hp = SendHp();
            Debug.Log($"{hp}");
            var items = SendItems();
            Debug.Log($"{items}");
            var playerData = new PlayerData
            {
                Hp = hp,
                PlayerPosition = (pos.x, pos.y, pos.z),
                BulletType = BulletEntity.Reader.CurrentValue,
                HoldItemIds = items,
            };
            return playerData;
        }

        private Vector3 SendPosition()
        {
            return PlayerView.ModelTransform.position;
        }

        private int SendHp()
        {
            return PlayerHpEntity.HpReader.CurrentValue;
        }

        private List<PlayerItem> SendItems()
        {
            return ItemEntity.ItemList;
        }

        private PlayerView PlayerView { get; }
        private MutPlayerHpEntity PlayerHpEntity { get; }
        private MutItemEntity ItemEntity { get; }
        private MutBulletEntity BulletEntity { get; }
        private PlayerDebugSymbol DebugSymbol { get; }
    }
}