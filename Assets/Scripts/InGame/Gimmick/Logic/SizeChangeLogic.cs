using DG.Tweening;
using InGame.Gimmick.Serializable;
using InGame.Gimmick.View;
using R3;
using UnityEngine;
using VContainer;

namespace InGame.Gimmick.Logic
{
    public class SizeChangeLogic
    {
        [Inject]
        public SizeChangeLogic(IIceAmountReader iceAmountReader, MeltIceConstant iceConstant
            , BulletHittableView view)
        {
            iceAmountReader.AmountReader.Subscribe(x =>
            {
                view.ModelTransform.DOScale(Remap(x, iceConstant.MinSize, iceConstant.MaxSize),
                    iceConstant.SizeChangeTime);
            }).AddTo(view);
        }

        private static Vector3 Remap(float percent, Vector3 min, Vector3 max)
        {
            return ((100 - percent) * min + percent * max) / 100f;
        }
    }
}