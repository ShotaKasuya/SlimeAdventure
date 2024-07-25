using System;
using UnityEngine;

namespace InGame.Gimmick.Serializable
{
    [Serializable]
    public class GimmickId
    {
        public int ID => id;

        [SerializeField] private int id;
    }
}