using UnityEngine;
using UnityEngine.Splines;

namespace InGame.Others
{
    public class SplineEventObject:MonoBehaviour
    {
        [SerializeField] private SplineAnimate particle;
        [SerializeField] private SplineContainer spline;

        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                var obj = Instantiate(particle, spline.transform);
                obj.Container = spline;
                Destroy(gameObject);
            }
        }
    }
}