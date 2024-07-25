using InGame.Item;
using InGame.Player;
using InGame.ScriptableObjects;
using InGame.UserInterface.View;
using R3;
using UnityEngine.UI;
using VContainer;

namespace InGame.UserInterface.Logic
{
    public class ShowItemLogic
    {
        [Inject]
        public ShowItemLogic(IItemReader itemReader, ItemDb itemDb,
            ItemUiView itemUiView, CompositeDisposable disposable)
        {
            itemReader.ItemObservable
                .Subscribe(x =>
                {
                    var itemListLength = itemReader.ItemReader.Count;
                    if (itemListLength == 0) return;
                    if (itemListLength >= 3)
                    {
                        ShowItem(itemUiView.LhsImage, itemUiView.LhsText, itemReader, itemDb, -1);
                        ShowItem(itemUiView.CenterImage, itemUiView.CenterText, itemReader, itemDb, 0);
                        ShowItem(itemUiView.RhsImage, itemUiView.RhsText, itemReader, itemDb, 1);
                        return;
                    }

                    if (itemListLength == 1)
                    {
                        ShowItem(itemUiView.CenterImage, itemUiView.CenterText, itemReader, itemDb, 0);
                        return;
                    }

                    if (itemReader.ItemCursorReader.CurrentValue == 0)
                    {
                        itemUiView.LhsImage.sprite = itemDb.Items[(int)ItemId.None].ItemSprite;
                        ShowItem(itemUiView.CenterImage, itemUiView.CenterText, itemReader, itemDb, 0);
                        if (itemListLength == 2)
                        {
                            itemUiView.RhsImage.sprite = itemDb.Items[(int)ItemId.None].ItemSprite;
                        }

                        ShowItem(itemUiView.RhsImage, itemUiView.RhsText, itemReader, itemDb, 1);
                    }
                    else
                    {
                        itemUiView.RhsImage.sprite = itemDb.Items[(int)ItemId.None].ItemSprite;
                        ShowItem(itemUiView.CenterImage, itemUiView.CenterText, itemReader, itemDb, 0);
                        if (itemListLength == 2)
                        {
                            itemUiView.LhsImage.sprite = itemDb.Items[(int)ItemId.None].ItemSprite;
                        }

                        ShowItem(itemUiView.LhsImage, itemUiView.LhsText, itemReader, itemDb, -1);
                    }
                }).AddTo(disposable);
        }

        private static void ShowItem(Image image, Text text, IItemReader itemReader, ItemDb itemDb, int addSub)
        {
            var index = itemReader.ItemCursorReader.CurrentValue + addSub;
            if (index < 0)
            {
                index = itemReader.ItemReader.Count - 1;
            }

            if (index >= itemReader.ItemReader.Count)
            {
                index = 0;
            }

            var playerItem = itemReader.ItemReader[index];
            image.sprite = itemDb.Items[(int)playerItem.Id].ItemSprite;
            text.text = playerItem.Count.ToString();
        }
    }
}