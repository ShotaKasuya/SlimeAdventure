using Cysharp.Threading.Tasks;
using InGame.Interface;
using InGame.Player;
using R3;
using StaticVariables;
using UnityEngine;
using VContainer;

namespace InGame.SceneRoot.Logic
{
    public class CameraEventLogic
    {
        [Inject]
        public CameraEventLogic(IPlayerStoppable playerStoppable,
            ICameraEventProvider eventProvider, CompositeDisposable disposable)
        {
            eventProvider.CameraEventObservable
                .SubscribeAwait(async (cameraEvent, token) =>
                {
                    Debug.Log("event visit");
                    cameraEvent.VirtualCamera.Priority = ConstantDefinition.MainVirtualCamera;
                    await UniTask.WaitForSeconds(cameraEvent.Duration, cancellationToken: token);
                    cameraEvent.VirtualCamera.Priority = ConstantDefinition.SubVirtualCamera;
                }).AddTo(disposable);
        }
    }
}