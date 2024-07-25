using InGame.Interface;
using InGame.Player.Entity;
using InGame.Player.View;
using R3;
using R3.Triggers;
using StaticVariables;
using UnityEngine;
using VContainer;

namespace InGame.Player.Logic
{
    public class GetItemLogic
    {
        [Inject]
        public GetItemLogic(PlayerView playerView, MutItemEntity itemEntity)
        {
            playerView.OnCollisionEnterAsObservable().Subscribe(itemEntity, (collision, entity) =>
            {
                if (!collision.gameObject.CompareTag(Tags.Item)) return;
                if (collision.gameObject.TryGetComponent<IGettableItem>(out var gettableItem))
                {
                    entity.AddItem(gettableItem.ItemId);
                    Object.Destroy(collision.gameObject);
                }
            }).AddTo(playerView);
        }
    }
}