using UnityEngine;

namespace Sanomic
{
    public class ElektronBehaviour : MonoBehaviour
    {
        [SerializeField] [Range(0f, 1000f)] private float _speed = 1f;
        [SerializeField] private Transform _center;
        [SerializeField] private Vector3 _axis = Vector3.up;
        
        private void Update()
        {
            transform.RotateAround(_center.position, _axis, _speed * Time.deltaTime);
        }
    }
}
