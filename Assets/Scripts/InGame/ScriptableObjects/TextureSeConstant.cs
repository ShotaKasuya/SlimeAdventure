using System.Collections.Generic;
using UnityEngine;

namespace InGame.ScriptableObjects
{
    [CreateAssetMenu(fileName = nameof(TextureSeConstant), menuName = "ScriptableObjects/TextureSeConstant")]
    public class TextureSeConstant: ScriptableObject
    {
        public IReadOnlyList<TextureSe> Ses => ses;

        [SerializeField] private List<TextureSe> ses;
    }
}