using System;
using InGame.Gimmick.Serializable;
using R3;
using VContainer;

namespace InGame.Gimmick.Logic
{
    public class LightVisualLogic
    {
        [Inject]
        public LightVisualLogic(IFireReader fireReader,
            ChangeableMaterialObject changeableMaterialObject
            , CompositeDisposable disposable)
        {
            fireReader.Reader.Subscribe(changeableMaterialObject, (info, material) =>
            {
                switch (info)
                {
                    case FireType.Burning:
                        material.Change();
                        break;
                    case FireType.None:
                        material.Reset();
                        break;
                    default:
                        throw new NotSupportedException();
                }
            }).AddTo(disposable);
        }
    }
}