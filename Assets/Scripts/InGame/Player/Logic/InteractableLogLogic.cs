using R3;
using UnityEngine;
using VContainer;

namespace InGame.Player.Logic
{
    public class InteractableLogLogic
    {
        [Inject]
        public InteractableLogLogic(IInteractableReader interactableReader)
        {
            // interactableReader.InteractableReader.Subscribe(x => { Debug.Log(x?.Type); });
        }
    }
}