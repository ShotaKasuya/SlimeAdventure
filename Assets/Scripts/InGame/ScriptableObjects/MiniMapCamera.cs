using UnityEngine;

namespace InGame.ScriptableObjects
{
    [CreateAssetMenu(fileName = nameof(MiniMapCamera), menuName = "ScriptableObjects/MiniMapCamera")]
    public class MiniMapCamera : ScriptableObject
    {
        [SerializeField] private Camera miniMapCamera;
    }
}