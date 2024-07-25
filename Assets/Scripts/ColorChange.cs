using UnityEngine;
public class ColorChange : MonoBehaviour
{
    [SerializeField] Material mat = default;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            this.GetComponent<MeshRenderer>().sharedMaterial = mat;
        }
    }
}
