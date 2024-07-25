using UnityEngine;

namespace InGame.Player.View
{
    public class PlayerView : MonoBehaviour, IPlayerAnimationCallback
    {
        public Transform ModelTransform => modelTransform;
        public Rigidbody ModelRigidbody => modelRigidbody;
        public Vector3 PlayerSize => modelTransform.lossyScale;
        public OnFootStomp FootStompEvent;

        [SerializeField] private Transform modelTransform;
        [SerializeField] private Rigidbody modelRigidbody;
        public void OnCallChangeFace(string str)
        {
        }

        public void OnFootStomp()
        {
            FootStompEvent?.Invoke();
        }

    }
}