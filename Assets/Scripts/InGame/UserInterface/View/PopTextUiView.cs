using UnityEngine;

namespace InGame.UserInterface.View
{
    public class PopTextUiView : MonoBehaviour
    {
        public Transform GroupTransform { get; private set; }

        private void Awake()
        {
            GroupTransform = transform;
        }
    }
}