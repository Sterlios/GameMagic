using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Mechanic
{
    public class Rotatable : MonoBehaviour
    {
        [SerializeField] private float _speed;

        public void Rotate(Vector3 direction)
        {
            if (Vector3.Angle(transform.forward, direction) != 0)
            {
                Vector3 newDirection = Vector3.RotateTowards(transform.forward, direction, _speed * Time.deltaTime, 0);
                transform.rotation = Quaternion.LookRotation(newDirection, Vector3.up);
            }
        }
    }
}
