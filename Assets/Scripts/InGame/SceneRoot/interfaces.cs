using R3;
using SaveData.DataDefinition;

namespace InGame.SceneRoot
{
    public interface IGameStateReader
    {
        public ReadOnlyReactiveProperty<GameStateType> Reader { get; }
    }

    public interface IGettableSaveData
    {
        public RootSaveData GetSaveData();
    }

    public interface ILoadable
    {
        public void Load(RootSaveData saveData);
    }

    /// <summary>
    /// ギミック?がシーンルートに対して渡すイベント。
    /// シーンが何かしらのイベントを検知する
    /// </summary>
    public interface IConvertible2ParentGimmickEvent
    {
        public ReadOnlyReactiveProperty<GameEventType> Reader { get; }
    }

}