using InGame.Gimmick.Container.Bases;
using InGame.Interface;
using InGame.Player.Container;
using VContainer;

namespace InGame.SceneRoot.Logic
{
    public class AppendEventProviderLogic
    {
        [Inject]
        public AppendEventProviderLogic(PlayerContainerBase playerContainerBase,
            ParentGimmickContainerBase[] parentGimmickContainerBases,
            IMessageEventReceiver messageReceiver, ICameraEventReceiver cameraEventReceiver,
            IStopEventReceiver stopEventReceiver)
        {
            messageReceiver.AppendEvent(playerContainerBase, playerContainerBase);
            foreach (var gimmickContainerBase in parentGimmickContainerBases)
            {
                messageReceiver.AppendEvent(gimmickContainerBase, gimmickContainerBase);
                cameraEventReceiver.AppendEvent(gimmickContainerBase, gimmickContainerBase);
            }
        }
    }
}