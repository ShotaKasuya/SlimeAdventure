using InGame.Gimmick.Serializable;
using R3;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace InGame.Gimmick.Container.Bases
{
    /// <summary>
    /// このギミック自体が何かをするというよりは
    /// プレイヤーのアクションを受け取り、
    /// 他のギミックにイベントを渡す役割
    /// </summary>
    public class ChildGimmickContainerBase : LifetimeScope, IConvertible2ChildGimmickEvent, IResettable
    {
        [SerializeField] private GimmickId gimmickId;

        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterInstance(gimmickId);
        }

        public Observable<GimmickEventInfo> GimmickEvent =>
            Container.Resolve<IConvertible2ChildGimmickEvent>().GimmickEvent;

        public void Reset()
        {
            Container.Resolve<IResettable>().Reset();
        }
    }
}