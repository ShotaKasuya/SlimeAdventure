using InGame.Gimmick.View;
using R3;
using VContainer;

namespace InGame.Gimmick.Logic
{
    public class MoveWithObjectLogic
    {
        [Inject]
        public MoveWithObjectLogic(GimmickViewBase viewBase)
        {
            viewBase.OnCollisionEnter.Subscribe(collider =>
            {
                collider.gameObject.transform.SetParent(viewBase.ModelTransform);
            }).AddTo(viewBase);
            viewBase.OnCollisionExit.Subscribe(collider => { collider.gameObject.transform.SetParent(null); })
                .AddTo(viewBase);
        }
    }
}