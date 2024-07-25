using InGame.Player;
using SaveData;
using SaveData.DataDefinition;
using UnityEngine;
using VContainer;

namespace InGame.SceneRoot.Logic
{
    public class SaveLogic : IGettableSaveData
    {
        [Inject]
        public SaveLogic(IPlayerSavable playerSavable)
        {
            PlayerSavable = playerSavable;
        }

        public RootSaveData GetSaveData()
        {
            var saveData = new RootSaveData
            {
                PlayerData = PlayerSavable.Save(),
            };
            return saveData;
        }

        public void Save()
        {
            var data = GetSaveData();
            Debug.Log($"{data}");
            SaveDataManager.Instance.Save(data);
        }

        private IPlayerSavable PlayerSavable { get; }
    }
}