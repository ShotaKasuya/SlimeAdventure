using InGame.Gimmick.Entity;
using R3;
using UnityEngine;
using VContainer;

namespace InGame.Gimmick.Logic
{
    public class ManageWaterColliderLogic
    {
        [Inject]
        public ManageWaterColliderLogic(MutWaterEntity waterEntity, BoxCollider collider,
            CompositeDisposable disposable)
        {
            waterEntity.Reader.Subscribe(collider, (type, boxCollider) =>
            {
                switch (type)
                {
                    case WaterType.Water:
                        boxCollider.enabled = false;
                        return;
                    case WaterType.Ice:
                        boxCollider.enabled = true;
                        return;
                }
            }).AddTo(disposable);
        }
    }
}