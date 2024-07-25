using System.Collections.Generic;
using System.Linq;
using InGame.ScriptableObjects;
using UnityEngine;

namespace SceneTransition
{
    [CreateAssetMenu(fileName = "SceneDefinition", menuName = "ScriptableObjects/Scenes")]
    public class SceneList : ScriptableObject
    {
        [HideInInspector] [SerializeField] private List<string> scenes;
        public IReadOnlyList<string> Scenes => scenes;
        
        
        

#if UNITY_EDITOR
        [SerializeField] private List<SceneAssetPair> sceneToLoadAsset;
        private void OnValidate()
        {
            scenes = sceneToLoadAsset.OrderBy(x => x.Scene).Select(x => x.SceneAsset.name).ToList();
        }
#endif
    }
}