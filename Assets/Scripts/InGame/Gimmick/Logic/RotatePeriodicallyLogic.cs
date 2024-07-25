using DG.Tweening;
using InGame.Gimmick.Entity;
using InGame.Gimmick.Serializable;
using VContainer;

namespace InGame.Gimmick.Logic
{
    public class RotatePeriodicallyLogic
    {
        [Inject]
        public RotatePeriodicallyLogic(RotatePeriodicallyInfo rotatePeriodicallyInfo,
            StoppableSequenceEntity stoppableSequenceEntity
        )
        {
            Sequence = DOTween.Sequence();
            foreach (var rotationCursor in rotatePeriodicallyInfo.RotationCursors)
            {
                Sequence.Append(rotatePeriodicallyInfo.RotateObject.ModelTransform.DORotate(rotationCursor,
                    rotatePeriodicallyInfo.RotationTime));
                Sequence.AppendInterval(rotatePeriodicallyInfo.Interval);
            }

            Sequence.SetLoops(-1, LoopType.Incremental);
        }

        private Sequence Sequence { get; }
    }
}