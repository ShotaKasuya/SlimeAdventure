using DG.Tweening;
using InGame.Player;
using InGame.UserInterface.Serializable;
using InGame.UserInterface.View;
using R3;
using VContainer;

namespace InGame.UserInterface.Logic
{
    public class HpGageLogic
    {
        [Inject]
        public HpGageLogic(PlayerHpUiView hpUiView, IHpReader hpReader, HpGageUiConstant hpGageUiConstant,
            CompositeDisposable disposable)
        {
            hpReader.HpReader.Subscribe(hpUiView,
                    (hp, view) => { view.HpImage.DOFillAmount((float)hp / hpReader.MaxHp, hpGageUiConstant.Duration); })
                .AddTo(disposable);
        }
    }
}