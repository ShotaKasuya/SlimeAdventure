using System;
using System.Collections.Generic;
using UnityEngine;

namespace InGame.Gimmick.Serializable
{
    [Serializable]
    public class ChangeableMaterialObject
    {
        public MeshRenderer TargetObject => targetObject;

        [SerializeField] private MeshRenderer targetObject;
        [SerializeField] private Material beforeMaterial;
        [SerializeField] private Material afterMaterial;
        [SerializeField] private List<GameObject> particleObjects;

        public void Change()
        {
            if (particleObjects.Count == 0)
            {
                TargetObject.material = afterMaterial;
            }
            else
            {
                foreach (var particleObject in particleObjects)
                {
                    particleObject.SetActive(true);
                }
            }
        }

        public void Reset()
        {
            if (particleObjects.Count == 0)
            {
                targetObject.material = beforeMaterial;
            }
            else
            {
                foreach (var particleObject in particleObjects)
                {
                    particleObject.SetActive(false);
                }
            }
        }
    }
}