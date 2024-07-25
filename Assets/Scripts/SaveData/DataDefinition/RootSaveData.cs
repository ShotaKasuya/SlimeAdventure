using InGame.ScriptableObjects;
using SceneTransition;
using MessagePack;

namespace SaveData.DataDefinition
{
    [MessagePackObject]
    public class RootSaveData
    {
        [Key(0)] public PlayerData PlayerData;
        [Key(1)] public SceneDefinition CurrentScene;
    }
}