using System.Threading;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using InGame.SceneRoot.Provider;
using InGame.UserInterface.Entity;
using InGame.UserInterface.Serializable;
using InGame.UserInterface.View;
using R3;
using UnityEngine;
using UnityEngine.UI;
using VContainer;

namespace InGame.UserInterface.Logic
{
    /// <summary>
    /// 仕様
    /// イベントを受け付けてメッセージを表示する
    /// メッセージを表示後一定時間たつと消える
    /// メッセージはすでに表示されているものがある場合、その下につく
    /// メッセージは多くなるとフェードする速度が上がる
    /// </summary>
    public class PopUpMessageLogic
    {
        [Inject]
        public PopUpMessageLogic(MessageEventProvider messageEventProvider, PopTextUiView view,
            PopUpTextConstant constant, PopUpTextEntity textEntity)
        {
            messageEventProvider.MessageEventObservable.SubscribeAwait(async (gameEvent, token) =>
            {
                await Semaphore.WaitAsync();
                // init
                Text textObject = Object.Instantiate(constant.TextPrefab, view.GroupTransform);
                textObject.text = gameEvent.Description;
                Transform textTransform = textObject.transform;
                RectTransform rectTransform = textObject.rectTransform;
                float textHeight = rectTransform.rect.height;
                var color = textObject.color;
                textObject.color = new Color(color.r, color.g, color.b, 0);
                rectTransform.anchoredPosition = new Vector2(0, -textHeight);

                textEntity.Scroll(textHeight, constant.FadeDuration);
                textEntity.AddText(textTransform);
                textObject.DOFade(1.0f, constant.FadeDuration).Play();
                await rectTransform.DOLocalMoveY(textHeight, constant.FadeDuration)
                    .SetRelative(true)
                    .AsyncWaitForCompletion();

                Semaphore.Release();

                await UniTask.WaitForSeconds(constant.TimeToLive);

                rectTransform.DOLocalMoveY(textHeight, constant.FadeDuration)
                    .SetRelative(true).Play();
                await textObject.DOFade(0.0f, constant.FadeDuration)
                    .AsyncWaitForCompletion();

                textEntity.RemoveText(textTransform);
                Object.Destroy(textObject.gameObject);
            }, AwaitOperation.Parallel).AddTo(view);
        }

        private SemaphoreSlim Semaphore { get; } = new SemaphoreSlim(1, 1);
    }
}