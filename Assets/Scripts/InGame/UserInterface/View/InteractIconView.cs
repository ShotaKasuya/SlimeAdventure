using UnityEngine;
using UnityEngine.UI;

namespace InGame.UserInterface.View
{
    public class InteractIconView : MonoBehaviour
    {
        public Text InteractUi { get; private set; }

        private void Awake()
        {
            InteractUi = GetComponent<Text>();
        }
    }
}