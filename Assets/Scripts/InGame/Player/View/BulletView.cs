using R3;
using R3.Triggers;
using UnityEngine;

namespace InGame.Player.View
{
    public class BulletView : MonoBehaviour
    {
        public Transform ModelTransform => modelTransform;
        public Rigidbody ModelRigidbody => modelRigidbody;
        public Observable<Collider> ObservableTriggerEnter => _triggerEnter;

        [SerializeField] private Transform modelTransform;
        [SerializeField] private Rigidbody modelRigidbody;
        private Observable<Collider> _triggerEnter;

        private void Awake()
        {
            _triggerEnter = this.OnTriggerEnterAsObservable();
        }
    }
}