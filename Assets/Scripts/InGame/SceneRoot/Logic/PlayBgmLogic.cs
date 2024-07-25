using System.Linq;
using InGame.ScriptableObjects;
using KanKikuchi.AudioManager;
using UnityEngine.SceneManagement;
using VContainer;

namespace InGame.SceneRoot.Logic
{
    public class PlayBgmLogic
    {
        [Inject]
        public PlayBgmLogic(BgmDb bgmDb)
        {
        }
    }
}