using UnityEngine;

namespace Sanomic
{
    public class AtomBehaviour : MonoBehaviour
    {
        private void Update()
        {
            transform.RotateAround(transform.position, Vector3.up, 1f * Time.deltaTime);
        }
    }
}
