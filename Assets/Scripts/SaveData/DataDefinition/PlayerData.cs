using System.Collections.Generic;
using InGame;
using InGame.Item;
using MessagePack;
using UnityEngine;

namespace SaveData.DataDefinition
{
    [MessagePackObject]
    public class PlayerData
    {
        [Key(0)] public int Hp;
        [Key(1)] public string FirstName;
        [Key(2)] public string LastName;
        [IgnoreMember] public string FullName => FirstName + LastName;
        [Key(3)] public (float x, float y, float z) PlayerPosition;
        [Key(4)] public BulletType BulletType;
        [Key(5)] public List<PlayerItem> HoldItemIds;
        [IgnoreMember] public Vector3 Position => new Vector3(PlayerPosition.x, PlayerPosition.y, PlayerPosition.z);
    }
}