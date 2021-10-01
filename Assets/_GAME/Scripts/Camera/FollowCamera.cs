using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CameraControl
{
    public class FollowCamera : MonoBehaviour
    {
        [SerializeField] private Transform target;
        [SerializeField] float smoothSpeed = 0.125f;
        public Vector3 offset;

        private void Update()
        {
            transform.position = Vector3.Lerp(transform.position, target.position + offset, smoothSpeed);
        }
    }

}