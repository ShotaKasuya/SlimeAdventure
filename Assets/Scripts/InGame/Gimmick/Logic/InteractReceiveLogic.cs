using InGame.Gimmick.View;
using VContainer;
using VContainer.Unity;

namespace InGame.Gimmick.Logic
{
    public class InteractReceiveLogic : IStartable
    {
        [Inject]
        public InteractReceiveLogic(GimmickViewBase view)
        {
            ViewBase = view;
        }

        public void Start()
        {
        }


        private GimmickViewBase ViewBase { get; }
    }
}