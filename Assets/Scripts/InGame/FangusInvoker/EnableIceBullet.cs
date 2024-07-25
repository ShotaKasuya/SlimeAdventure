using StaticVariables;
using UnityEngine;

namespace InGame.FangusInvoker
{
    public class EnableIceBullet : MonoBehaviour
    {
        public void Event()
        {
            PlayerUsableBullets.IceBullet = true;
        }
    }
}