using System;
using DG.Tweening;

namespace InGame.Gimmick.Entity
{
    // FIXME
    public class StoppableSequenceEntity : ISequenceAppender, IDisposable
    {
        public StoppableSequenceEntity()
        {
            Sequence = DOTween.Sequence();
        }

        public void Dispose()
        {
            Sequence?.Kill();
        }

        public void Append(Tween tween)
        {
            Sequence.Append(tween);
        }

        public void Stop()
        {
        }

        private Sequence Sequence { get; }
    }
}