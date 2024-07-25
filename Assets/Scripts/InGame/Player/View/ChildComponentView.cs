using UnityEngine;

namespace InGame.Player.View
{
    public class ChildComponentView : MonoBehaviour
    {
        public Transform CameraTransform => cameraTransform;
        public Transform CameraRotator => cameraRotator;
        public Vector3 GetGroundRaycastPos => groundRaycastPos.position;
        public Vector3 ShootPos => shootPos.position;

        [SerializeField] private Transform groundRaycastPos;
        [SerializeField] private Transform cameraTransform;
        [SerializeField] private Transform cameraRotator;
        [SerializeField] private Transform shootPos;
    }
}