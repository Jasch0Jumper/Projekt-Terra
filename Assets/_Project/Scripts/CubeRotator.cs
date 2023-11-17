using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sanomic
{
    public class CubeRotator : MonoBehaviour
    {
        public Vector3 Moment;
        public float rotationSpeed = 1f;
        
        // Start is called before the first frame update
        void Start()
        {
            transform.rotation = Quaternion.identity;
        }

        // Update is called once per frame
        void Update()
        {
            var position = transform.position;
            transform.RotateAround(position, Vector3.right, Moment.x * rotationSpeed * Time.deltaTime);
            transform.RotateAround(position, Vector3.up, Moment.y * rotationSpeed * Time.deltaTime);
            transform.RotateAround(position, Vector3.forward, Moment.z * rotationSpeed * Time.deltaTime);
        }
    }
}
