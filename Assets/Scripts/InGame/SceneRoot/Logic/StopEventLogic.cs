using System;
using Cysharp.Threading.Tasks;
using InGame.Interface;
using InGame.Player;
using R3;
using VContainer;

namespace InGame.SceneRoot.Logic
{
    public class StopEventLogic
    {
        [Inject]
        public StopEventLogic(IStopEventProvider eventProvider,
            IPlayerStoppable playerStoppable, CompositeDisposable disposable)
        {
            eventProvider.StopEventObservable
                .SubscribeAwait(async (stopEvent, token) =>
                {
                    switch (stopEvent.EventType)
                    {
                        case StopEventType.StopForSeconds:
                            playerStoppable.Stop();
                            await UniTask.WaitForSeconds(stopEvent.StopTime);
                            playerStoppable.Restart();
                            break;
                        case StopEventType.StopUntilRestart:
                            playerStoppable.Stop();
                            break;
                        case StopEventType.Restart:
                            playerStoppable.Restart();
                            break;
                        default:
                            throw new NotImplementedException();
                    }
                }, AwaitOperation.Parallel).AddTo(disposable);
        }
    }
}