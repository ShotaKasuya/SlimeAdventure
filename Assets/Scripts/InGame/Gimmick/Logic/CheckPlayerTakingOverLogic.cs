using InGame.Gimmick.Entity;
using InGame.Gimmick.Serializable;
using InGame.Gimmick.View;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace InGame.Gimmick.Logic
{
    public class CheckPlayerTakingOverLogic : IFixedTickable
    {
        [Inject]
        public CheckPlayerTakingOverLogic(GimmickViewBase viewBase, MutSwitchEntity playerTakingOverEntity,
            SwitchConstant switchConstant)
        {
            ViewBase = viewBase;
            PlayerTakingOverEntity = playerTakingOverEntity;
            SwitchConstant = switchConstant;
        }

        public void FixedTick()
        {
            if (SwitchConstant.IsOnlyOnce && PlayerTakingOverEntity.SwitchReader.CurrentValue == SwitchType.On)
            {
                return;
            }

            var isHit = Physics.BoxCast(ViewBase.ModelTransform.position,
                SwitchConstant.CastCube, Vector3.up, Quaternion.identity
                , SwitchConstant.Distance, SwitchConstant.TargetLayer
            );

            PlayerTakingOverEntity.SetValue(isHit ? SwitchType.On : SwitchType.Off);
        }

        private GimmickViewBase ViewBase { get; }
        private MutSwitchEntity PlayerTakingOverEntity { get; }
        private SwitchConstant SwitchConstant { get; }
    }
}