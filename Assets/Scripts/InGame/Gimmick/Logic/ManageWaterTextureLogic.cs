using InGame.Gimmick.Entity;
using InGame.Gimmick.Serializable;
using R3;
using VContainer;

namespace InGame.Gimmick.Logic
{
    public class ManageWaterTextureLogic
    {
        [Inject]
        public ManageWaterTextureLogic(MutWaterEntity waterEntity, ChangeableMaterialObject materialChange)
        {
            waterEntity.Reader.Subscribe(materialChange, (type, material) =>
            {
                switch (type)
                {
                    case WaterType.Water:
                        material.Reset();
                        return;
                    case WaterType.Ice:
                        material.Change();
                        return;
                }
            }).AddTo(materialChange.TargetObject);
        }
    }
}