namespace InGame.Interface
{
    public interface IHitBullet
    {
        public void OnHit(BulletInfo bulletInfo);
    }

    public struct BulletInfo
    {
        public BulletInfo(BulletType bulletType, int power)
        {
            BulletType = bulletType;
            Power = power;
        }

        public int Power { get; }
        public BulletType BulletType { get; }
    }
}