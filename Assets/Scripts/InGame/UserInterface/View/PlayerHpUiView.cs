using UnityEngine;
using UnityEngine.UI;

namespace InGame.UserInterface.View
{
    public class PlayerHpUiView : MonoBehaviour
    {
        public Image HpImage => hpImage;

        [SerializeField] private Image hpImage;
    }
}