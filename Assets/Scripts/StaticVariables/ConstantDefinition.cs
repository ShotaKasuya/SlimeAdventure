namespace StaticVariables
{
    public static class InputDefinition
    {
        public static string MoveAction { get; } = "Move";
        public static string JumpAction { get; } = "Jump";
        public static string CameraAction { get; } = "Mouse";
        public static string DashAction { get; } = "Dash";
        public static string ShootAction { get; } = "Shoot";
        public static string EndGameAction { get; } = "GameEnd";
        public static string BulletChangeAction { get; } = "BulletChange";
        public static string ChangeItemAction { get; } = "ChangeItem";
        public static string UseItemAction { get; } = "UseItemAction";
        public static string Interact { get; } = "Interact";
    }

    public static class AnimationDefinition
    {
        public static string IsGround { get; } = "IsGround";
        public static string Speed { get; } = "Speed";
        public static string Jump { get; } = "JumpTrigger";
    }
    public static class ConstantDefinition
    {
        public static string DefaultSaveDataName { get; } = "default";
        public static int MainVirtualCamera { get; } = 100;
        public static int SubVirtualCamera { get; } = 5;
    }

    public static class Tags
    {
        public static string Grand { get; } = "Ground";
        public static string Item { get; } = "Item";
    }
}