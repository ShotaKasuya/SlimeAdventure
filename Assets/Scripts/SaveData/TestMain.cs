using System.IO;
using MessagePack;
using SaveData.DataDefinition;
using UnityEngine;

namespace SaveData
{
    public class TestMain : MonoBehaviour
    {
        private void Start()
        {
            var saveData = new RootSaveData();
            saveData.PlayerData = new PlayerData();
            saveData.PlayerData.Hp = 10;

            var saveFileName = "sav";

            string saveDataDirectory = $"{Application.dataPath}/SaveData";

            var filePath = $"{saveDataDirectory}/{saveFileName}";

            RootSaveData tmp;

            using (var fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                byte[] bytes = new byte[fs.Length];
                fs.Read(bytes, 0, bytes.Length);
                tmp = MessagePackSerializer.Deserialize<RootSaveData>(bytes);
            }
            // SaveDataManager.Instance.Save(saveData, saveFileName);
            // var tmp = SaveDataManager.Instance.Load(saveFileName);

            Debug.Log(tmp.PlayerData.Hp);
        }
    }
}