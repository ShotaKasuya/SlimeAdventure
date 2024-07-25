using System.Threading;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using InGame.Player;
using InGame.UserInterface.Serializable;
using InGame.UserInterface.View;
using R3;
using UnityEngine;
using VContainer;

namespace InGame.UserInterface.Logic
{
    public class BulletChangeUiLogic
    {
        [Inject]
        public BulletChangeUiLogic(BulletTypeUiView bulletTypeUiView,
            IBulletTypeReader bulletTypeReader, BulletUiConstant bulletUiConstant
            , CompositeDisposable disposable)
        {
            BulletUiConstant = bulletUiConstant;
            TypeUiView = bulletTypeUiView;
            bulletTypeReader.Reader.SubscribeAwait(ChangeUi).AddTo(disposable);
        }

        private async ValueTask ChangeUi(BulletType type, CancellationToken token)
        {
            var task = TypeUiView.ModelTransform.DOScale(Vector3.zero, BulletUiConstant.PopUpDuration)
                .SetEase(BulletUiConstant.PopUpEase).AsyncWaitForCompletion();
            task.AddTo(token);
            await task;

            TypeUiView.BulletTypeImage.sprite = BulletUiConstant.GetSprite(type);

            task = TypeUiView.ModelTransform
                .DOScale(new Vector3(1, 1, 1), BulletUiConstant.PopUpDuration)
                .SetEase(BulletUiConstant.PopUpEase).AsyncWaitForCompletion();
            task.AddTo(token);
            await task;
        }
        
        private BulletTypeUiView TypeUiView { get; }
        private BulletUiConstant BulletUiConstant { get; }
    }
}