using UnityEngine;
using UnityEngine.UI;

namespace InGame.UserInterface.View
{
    [RequireComponent(typeof(Image))]
    public class BulletTypeUiView : MonoBehaviour
    {
        public Transform ModelTransform { get; private set; }
        public Image BulletTypeImage { get; private set; }

        private void Awake()
        {
            ModelTransform = transform;
            BulletTypeImage = GetComponent<Image>();
        }
    }
}