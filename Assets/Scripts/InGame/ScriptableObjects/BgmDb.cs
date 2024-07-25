using System.Collections.Generic;
using UnityEngine;

namespace InGame.ScriptableObjects
{
    [CreateAssetMenu(fileName = nameof(BgmDb), menuName = "ScriptableObjects/BGMDb")]
    public class BgmDb: ScriptableObject
    {
        public IReadOnlyList<BgmPair> BGMPairs => bgmPairs;

        [SerializeField] private List<BgmPair> bgmPairs;
    }
}