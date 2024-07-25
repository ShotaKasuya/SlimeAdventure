using InGame.Player.View;
using InGame.ScriptableObjects;
using SaveData;
using SaveData.DataDefinition;
using StaticVariables;
using UnityEngine;
using UnityEngine.InputSystem;
using VContainer;
using VContainer.Unity;

namespace InGame.Player.Logic
{
    /// <summary>
    /// 仮実装
    /// </summary>
    public class EscapeGameLogic : ITickable
    {
        [Inject]
        public EscapeGameLogic(PlayerInput playerInput, PlayerView playerView, IHpReader playerHpReader,
            PlayerDebugSymbol debugSymbol)
        {
            EscapeKey = playerInput.actions[InputDefinition.EndGameAction];
            PlayerView = playerView;
            PlayerHpReader = playerHpReader;
            if (debugSymbol.EraseCursor)
            {
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
            }
        }

        public void Tick()
        {
            if (ReadValue())
            {
                var pos = PlayerView.ModelTransform.position;
                var playerData = new PlayerData
                {
                    Hp = PlayerHpReader.HpReader.CurrentValue,
                    FirstName = "default",
                    LastName = "taro",
                    PlayerPosition = (pos.x, pos.y, pos.z),
                    HoldItemIds = null
                };
                var saveData = new RootSaveData { PlayerData = playerData };
                // SaveDataManager.Instance.Save(saveData);
#if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
#else
                Application.Quit();
#endif
            }
        }

        private bool ReadValue()
        {
            return EscapeKey.ReadValue<float>() != 0;
        }

        private InputAction EscapeKey { get; }
        private PlayerView PlayerView { get; }
        private IHpReader PlayerHpReader { get; }
    }
}