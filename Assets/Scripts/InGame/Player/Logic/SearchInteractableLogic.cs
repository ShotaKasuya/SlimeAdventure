using InGame.Interface;
using InGame.Player.Entity;
using InGame.Player.View;
using InGame.ScriptableObjects;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace InGame.Player.Logic
{
    public class SearchInteractableLogic : ITickable
    {
        [Inject]
        public SearchInteractableLogic(PlayerView playerView,
            MutInteractableEntity interactableEntity,
            ItemUseConstant itemUseConstant)
        {
            PlayerView = playerView;
            InteractableEntity = interactableEntity;
            ItemUseConstant = itemUseConstant;
        }

        public void Tick()
        {
            if (Physics.SphereCast(PlayerView.ModelTransform.position, PlayerView.PlayerSize.x,
                    PlayerView.ModelTransform.forward, out var hit,
                    ItemUseConstant.InteractDistanceMax, ItemUseConstant.InteractableLayerMask))
            {
                if (hit.collider.gameObject.TryGetComponent(out IInteractable interactable))
                {
                    InteractableEntity.Interactable.Value = interactable;
                }
            }
            else
            {
                InteractableEntity.Interactable.Value = null;
            }
        }

        private PlayerView PlayerView { get; }
        private MutInteractableEntity InteractableEntity { get; }
        private ItemUseConstant ItemUseConstant { get; }
    }
}