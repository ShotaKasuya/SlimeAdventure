using InGame.Item;

namespace InGame.Interface
{
    public interface IInteractable
    {
        public bool NowInteractable { get; }
        public InteractType Type { get; }
        public ItemId RequestItem { get; }
        public void OnInteract(InteractInfo interactInfo);
    }

    public struct InteractInfo
    {
        public InteractInfo(InteractType type)
        {
            Type = type;
        }

        public InteractType Type { get; }
    }
}