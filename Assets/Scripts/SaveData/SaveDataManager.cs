using System.IO;
using MessagePack;
using SaveData.DataDefinition;
using UnityEngine;

namespace SaveData
{
    public class SaveDataManager
    {
        private SaveDataManager()
        {
            SaveData = Load();
        }
        public static SaveDataManager Instance { get; } = new SaveDataManager();
        private string SaveDataDirectory { get; } = $"{Application.dataPath}/SaveData";
        private string FileName { get; } = "data.sav";
        public RootSaveData SaveData { get; }

        public void Save(RootSaveData saveData)
        {
            var bytes = MessagePackSerializer.Serialize(saveData);

            Directory.CreateDirectory(SaveDataDirectory);

            var filePath = $"{SaveDataDirectory}/{FileName}";

            using (var fs = new FileStream(filePath, FileMode.OpenOrCreate))
            {
                fs.Write(bytes, 0, bytes.Length);
            }
        }

        /// <summary>
        /// セーブデータがない時nullを返す
        /// </summary>
        /// <returns>セーブデータ?</returns>
        public RootSaveData Load()
        {
            var filePath = $"{SaveDataDirectory}/{FileName}";

            try
            {
                using (var fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                {
                    byte[] bytes = new byte[fs.Length];
                    _ = fs.Read(bytes, 0, bytes.Length);
                    return MessagePackSerializer.Deserialize<RootSaveData>(bytes);
                }
            }
            catch
            {
                return null;
            }
        }
    }
}