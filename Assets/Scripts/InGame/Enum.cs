namespace InGame
{
    public enum PlayerStateType
    {
        Idle,
        Walk,
        Jump,
        Shot,
    }

    public enum InteractType
    {
        UseKey,
        OpenBox,
        None,
    }

    public enum BulletType
    {
        Fire,
        Ice,
        Bolt,
    }

    public enum AttackStateType
    {
        None,
        Shoot,
        Charging,
        Charged,
    }

    public enum ChangeBulletInputType
    {
        Left, // input < 0
        None, // input == 0
        Right, // input > 0
    }

    public enum ItemType
    {
        Barrier,
        AtkUp,
        Heal,
        Regeneration,
        Key,
    }

    public enum GimmickStateType
    {
        NotCompleted,
        Completed,
    }

    public enum GameStateType
    {
        Play,
        Pause,
    }

    public enum GameEventType
    {
        DoorOpen,
        DoorClose,
        FloorMove,
        FloorStop,
        GetItem,
        LostItem,
    }
}