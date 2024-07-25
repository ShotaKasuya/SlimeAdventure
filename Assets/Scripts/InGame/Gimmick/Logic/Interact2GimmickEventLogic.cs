using System;
using InGame.Gimmick.Provider;
using InGame.Gimmick.Serializable;
using InGame.Gimmick.View;
using R3;
using VContainer;

namespace InGame.Gimmick.Logic
{
    public class Interact2GimmickEventLogic
    {
        [Inject]
        public Interact2GimmickEventLogic(InteractableGimmickView gimmickView,
            GimmickEventProvider gimmickEventProvider)
        {
            gimmickEventProvider.AppendProvider(
                gimmickView.InteractObservable.Where(x => x.Type != InteractType.None).Select(x =>
                    {
                        return x.Type switch
                        {
                            InteractType.UseKey => new GimmickEventInfo(GimmickEventType.OnUsedKey, 0),
                            _ => throw new NotImplementedException()
                        };
                    }
                ));
        }
    }
}