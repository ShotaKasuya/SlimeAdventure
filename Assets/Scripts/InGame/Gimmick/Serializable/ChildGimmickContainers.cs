using System;
using System.Collections.Generic;
using InGame.Gimmick.Container.Bases;
using UnityEngine;

namespace InGame.Gimmick.Serializable
{
    [Serializable]
    public class ChildGimmickContainers
    {
        public List<ChildGimmickContainerBase> GimmickContainers => gimmickContainers;

        public void Reset()
        {
            foreach (var container in gimmickContainers)
            {
                container.Reset();
            }
        }

        [SerializeField] private List<ChildGimmickContainerBase> gimmickContainers;
    }
}