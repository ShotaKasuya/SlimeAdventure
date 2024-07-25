using UnityEngine;
using UnityEngine.UI;

namespace InGame.UserInterface.View
{
    public class ItemUiView : MonoBehaviour
    {
        public Image CenterImage => centerImage;
        public Image RhsImage => rhsImage;
        public Image LhsImage => lhsImage;
        public Text CenterText => centerText;
        public Text RhsText => rhsText;
        public Text LhsText => lhsText;

        [SerializeField] private Image centerImage;
        [SerializeField] private Text centerText;
        [SerializeField] private Image rhsImage;
        [SerializeField] private Text rhsText;
        [SerializeField] private Image lhsImage;
        [SerializeField] private Text lhsText;
    }
}