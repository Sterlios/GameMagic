using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Mechanic
{
    public class Jumpable : MonoBehaviour
    {
        [SerializeField] private float _force;

        public bool Jump(out float velocity)
        {
            velocity = Mathf.Sqrt(_force * WorldPhysics.DefaultVelocity * WorldPhysics.Gravity);

            return true;
        }
    }
}
