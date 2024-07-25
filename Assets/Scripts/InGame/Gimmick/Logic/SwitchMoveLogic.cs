using DG.Tweening;
using InGame.Gimmick.Serializable;
using InGame.Gimmick.View;
using R3;
using VContainer;

namespace InGame.Gimmick.Logic
{
    public class SwitchMoveLogic
    {
        [Inject]
        public SwitchMoveLogic(ISwitchStateReader switchStateReader,
            GimmickViewBase gimmickViewBase, SwitchConstant switchConstant)
        {
            switchStateReader.SwitchReader
                .Subscribe((x) =>
                {
                    switch (x)
                    {
                        case SwitchType.On:
                            gimmickViewBase.ModelTransform.DOMoveY(switchConstant.PushDownPosY,
                                switchConstant.SwitchPushTime);
                            break;
                        case SwitchType.Off:
                            gimmickViewBase.ModelTransform.DOMoveY(switchConstant.DefaultPosY,
                                switchConstant.SwitchPushTime);
                            break;
                    }
                }).AddTo(gimmickViewBase);
        }
    }
}