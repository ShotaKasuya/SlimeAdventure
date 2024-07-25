using System;
using System.Linq;
using DG.Tweening;
using InGame.Item;
using InGame.Player;
using InGame.UserInterface.Serializable;
using InGame.UserInterface.View;
using R3;
using VContainer;

namespace InGame.UserInterface.Logic
{
    public class InteractIconLogic
    {
        [Inject]
        public InteractIconLogic(IInteractableReader interactableReader,
            InteractIconView iconView, IItemReader itemReader, InteractIconConstant constant)
        {
            interactableReader.InteractableReader
                .Subscribe(iconView, (interactable, view) =>
                {
                    if (interactable is null || !interactable.NowInteractable)
                    {
                        view.InteractUi.DOFade(0, constant.FadeDuration);
                    }
                    else
                    {
                        view.InteractUi.DOFade(1.0f, constant.FadeDuration);
                        switch (interactable.Type)
                        {
                            case InteractType.OpenBox:
                                view.InteractUi.text = constant.ItemBoxMessage;
                                break;
                            case InteractType.UseKey:
                                if (itemReader.ItemReader.Any(x => x.Id == ItemId.Key))
                                {
                                    view.InteractUi.text = constant.HasKeyMessage;
                                }
                                else
                                {
                                    view.InteractUi.text = constant.NoKeyMessage;
                                }

                                break;
                            case InteractType.None:
                                view.InteractUi.DOFade(0, constant.FadeDuration);
                                break;
                            default:
                                throw new NotImplementedException();
                        }
                    }
                }).AddTo(iconView);
        }
    }
}