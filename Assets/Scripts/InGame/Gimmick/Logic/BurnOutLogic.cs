using Cysharp.Threading.Tasks;
using InGame.Gimmick.Entity;
using InGame.Gimmick.Serializable;
using InGame.Gimmick.View;
using R3;
using VContainer;
using Object = UnityEngine.Object;

namespace InGame.Gimmick.Logic
{
    public class BurnOutLogic
    {
        [Inject]
        public BurnOutLogic(MutFireEntity fireEntity, BulletHittableView gimmickViewBase, PlantInfo info)
        {
            Fire = fireEntity;
            Fire.Reader.Where(type => type == FireType.Burning)
                .SubscribeAwait(async (_, ct) =>
                {
                    await UniTask.WaitForSeconds(info.BurnOutTime, cancellationToken: ct);
                    Object.Destroy(gimmickViewBase.gameObject);
                }, AwaitOperation.Drop)
                .AddTo(gimmickViewBase);
        }

        private IFireReader Fire { get; }
    }
}