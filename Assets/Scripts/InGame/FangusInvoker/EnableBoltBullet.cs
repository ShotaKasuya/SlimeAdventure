using StaticVariables;
using UnityEngine;

public class EnableBoltBullet : MonoBehaviour
{
    public void Enable()
    {
        PlayerUsableBullets.BoltBullet = true;
    }
}
