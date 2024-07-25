using System;
using KanKikuchi.AudioManager;
using UnityEngine;

namespace InGame.Gimmick.Serializable
{
    [Serializable]
    public class MeltIceConstant
    {
        public float InitValuePercentage => initValuePercentage;
        public Vector3 MaxSize => maxSize;
        public Vector3 MinSize => minSize;
        public float SizeChangeTime => sizeChangeTime;
        public float Delta => delta;
        public string MeltSe => meltSe;
        public string FreezeSe => freezeSe;

        [SerializeField] [Range(0, 100)] private float initValuePercentage;
        [SerializeField] private Vector3 maxSize;
        [SerializeField] private Vector3 minSize;
        [SerializeField] private float sizeChangeTime;

        [Header("delta when bullet hit melt or freeze amount")] [SerializeField] [Range(0, 100f)]
        private float delta;

        [SerializeField] [DropdownConstants(typeof(SEPath))]
        private string meltSe;

        [SerializeField] [DropdownConstants(typeof(SEPath))]
        private string freezeSe;
    }
}