using InGame.Player;
using InGame.UserInterface.Serializable;
using InGame.UserInterface.View;
using R3;
using UnityEngine;
using VContainer;

namespace InGame.UserInterface.Logic
{
    public class ItemChangeLogic
    {
        [Inject]
        public ItemChangeLogic(IItemReader itemReader, ItemUiConstant itemUiConstant,
            ItemUiView itemUiView)
        {
        }
    }
}