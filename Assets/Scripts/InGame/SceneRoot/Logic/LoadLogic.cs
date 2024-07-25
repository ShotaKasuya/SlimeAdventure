using System.Collections.Generic;
using SaveData.DataDefinition;
using UnityEngine;
using VContainer;

namespace InGame.SceneRoot.Logic
{
    public class LoadLogic : ILoadable
    {
        [Inject]
        public LoadLogic(IEnumerable<ILoadable> loadables)
        {
            Loadables = loadables;
        }

        public void Load(RootSaveData saveData)
        {
            if (saveData is null)
            {
                Debug.Log("save data null");
                return;
            }

            if (saveData.PlayerData is null)
            {
                Debug.Log("player save data null");
                return;
            }

            foreach (var loadable in Loadables)
            {
                loadable.Load(saveData);
            }
        }

        private IEnumerable<ILoadable> Loadables { get; }
    }
}